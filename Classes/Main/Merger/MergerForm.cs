using OsuHelperTool.Classes.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Main.Merger
{
    public partial class MergerForm : Form
    {
        #region setup

        private bool directlyDropped = false;
        

        public MergerForm()
        {
            InitializeComponent();
            directlyDropped = false;
        }

        private void MergerForm_Load(object sender, EventArgs e)
        {
            try
            {
                MapsetSelect.Items.Clear();
                string[] files = Directory.GetFiles(ChildFormConfig.GetMapsetPath());

                foreach (string file in files)
                {
                    if (file.Contains(".osu"))
                    {
                        MapsetSelect.Items.Add(Path.GetFileName(file));
                    }
                }
                Exceptions.CheckNumOfFiles(MapsetSelect.Items.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetColor(ChildFormConfig.GetBackColor(), this);
            SetColor(ChildFormConfig.GetMainButtonColor(), MergeButton, Reload);
        }

        private void SetColor(Color color, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.BackColor = color;
            }
        }

        private void MapsetSelect_MouseDown(object sender, MouseEventArgs e)
        {
            try
            { MergeList.DoDragDrop(MapsetSelect.SelectedItem.ToString(), DragDropEffects.Copy); }
            catch { }
        }

        private void MergeList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void MergeList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                MergeList.Items.Add(e.Data.GetData(DataFormats.Text));
                MapsetSelect.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
            else
            {
                string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in droppedFiles)
                {
                    string filename = Path.GetFileName(file);
                    if (filename.Contains(".osu"))
                    { MergeList.Items.Add(filename); }
                }

                if (!directlyDropped)
                {
                    MessageBox.Show("Please be aware that the directory of the directly dropped files requires to have the same directory as the one set in preferences. If not, please set it via preferences.");
                    directlyDropped = true;
                }
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            MergerForm mergerForm = new MergerForm();

            ChildFormConfig.ReloadChildform(this, mergerForm);
        }

        #endregion setup

        private async void MergeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MergeList.Items.Count >= 2)
                {
                    Task<Exception> task = new Task<Exception>(PopupManager);
                    task.Start();

                    MergeButton.Text = "Processing...";
                    Exception a = await task;
                    if (a == Exceptions.CancelOperation)
                    {
                        throw a;
                    }
                    MergeButton.Text = "Done";
                }
                else
                {
                    MessageBox.Show("Please put at least 2 files to continue.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        

        private Exception PopupManager()
        {
            // try
            // {
            List<string> Files = new List<string>();
            List<string> FilesForEMessageBox = new List<string>();

            foreach (var file in MergeList.Items)
            {
                Files.Add($@"{ChildFormConfig.GetMapsetPath()}\{file}");
                FilesForEMessageBox.Add(file.ToString());
            }

            #region gets timing panels VAR = TimingPoints

            List<List<string>> TimingPoints = new List<List<string>>();

            foreach (var file in Files)
            {
                StreamReader sr = new StreamReader(file);
                //Read the first line of text
                var line = sr.ReadLine();
                //Continue to read until you reach end of file

                while (line != "[TimingPoints]")
                {
                    line = sr.ReadLine();
                }

                line = sr.ReadLine();

                List<string> List = new List<string>();

                while (line != "")
                {
                    List.Add(line);
                    line = sr.ReadLine();
                }

                TimingPoints.Add(List);

                //close the file
                sr.Close();
            }

            #endregion gets timing panels VAR = TimingPoints

            #region gets hitobjects VAR = HitObjects

            List<List<string>> HitObjects = new List<List<string>>();

            foreach (var file in Files)
            {
                StreamReader sr = new StreamReader(file);
                //Read the first line of text
                var line = sr.ReadLine();
                //Continue to read until you reach end of file

                while (line != "[HitObjects]")
                {
                    line = sr.ReadLine();
                }

                line = sr.ReadLine();

                List<string> List = new List<string>();

                while (line != null)
                {
                    List.Add(line);
                    line = sr.ReadLine();
                }

                HitObjects.Add(List);

                //close the file
                sr.Close();
            }

            #endregion gets hitobjects VAR = HitObjects

            List<List<string>> FinalTimingPoint = new List<List<string>>();
            List<List<string>> FinalHitObjects = new List<List<string>>();

            Exception operationCancelled = new Exception();

            var UninheritedPoints = GetUP(TimingPoints);

            // credit https://www.youtube.com/watch?v=8aDsXyiBLsI&list=LL&index=5

            using (Bpm_Offset_ErrorMessageBox EBox = new Bpm_Offset_ErrorMessageBox(TimingPoints, UninheritedPoints, FilesForEMessageBox))
            {
                Invoke((Action)(() => { EBox.ShowDialog(); }));
                if (EBox.DialogResult == DialogResult.Ignore)
                {
                    FinalTimingPoint = EBox.newTimingPoint;
                    FinalHitObjects = HitObjects;
                    StartMerge(FinalHitObjects, FinalTimingPoint);
                }
                else if (EBox.DialogResult == DialogResult.OK)
                {
                    FinalTimingPoint = EBox.newTimingPoint;
                    FinalHitObjects = HitObjects;
                    StartMerge(FinalHitObjects, FinalTimingPoint);
                }
                else
                {
                    operationCancelled = Exceptions.CancelOperation;
                }
            }

            return operationCancelled;
        }

        private List<List<string>> GetUP(List<List<string>> TimingPoints)
        {
            List<List<string>> UninheritedPoints = new List<List<string>>();

            for(int y = 0; y < TimingPoints.Count; y = y + 1)
            {
                for (int i = 0; i < TimingPoints[y].Count; i = i + 1)
                {
                    string[] split = TimingPoints[y][i].Split(',');

                    List<string> Temp = new List<string>();

                    if (!split[1].Contains("-"))
                    {
                        Temp.Add(split[0]);
                        Temp.Add(split[1]);
                        Temp.Add(y.ToString());
                        UninheritedPoints.Add(Temp);
                        
                    }
                }
            }

            return UninheritedPoints;
        }

        #region for merging the final things only

        private void StartMerge(List<List<string>> HitObjects, List<List<string>> TimingPoints)
        {
            List<string> FinalHitObjects = mergeLists(HitObjects, false);
            List<string> FinalTimingPoints = mergeLists(TimingPoints, true);

            StreamReader sr = new StreamReader($@"{ChildFormConfig.GetMapsetPath()}\{MergeList.Items[0]}");

            var line = sr.ReadLine();

            List<string> template = new List<string>();

            while (line.Contains("Version:") == false)
            {
                template.Add(line);
                line = sr.ReadLine();
            }

            using (VersionName VName = new VersionName())
            {
                Invoke((Action)(() => { VName.ShowDialog(); }));
                if (VName.DialogResult == DialogResult.OK)
                {
                    line = $"Version: {VName.VersionNameV}";
                }
            }

            while (line != "[TimingPoints]")
            {
                template.Add(line);
                line = sr.ReadLine();
            }

            template.Add("[TimingPoints]");

            foreach (var lines in FinalTimingPoints)
            {
                template.Add(lines);
            }

            while (line != "")
            {
                line = sr.ReadLine();
            }

            while (line != "[HitObjects]")
            {
                template.Add(line);
                line = sr.ReadLine();
            }

            template.Add("[HitObjects]");

            foreach (var lines in FinalHitObjects)
            {
                template.Add(lines);
            }

            //close the file
            sr.Close();

            //File.WriteAllLines(@"C:\Users\juliu\Desktop\Osu!\Songs\Camellia - Camellia 200Step Mix/testtest.txt", template);

            string FileName = "Merged";
            string BaseFileName = "Merged";
            int i = 1;

            while (File.Exists($"{ChildFormConfig.GetMapsetPath()}/{FileName}.osu")) // https://stackoverflow.com/questions/5270919/always-create-new-file-if-file-already-exists-with-same-location-in-c-sharp
            {
                i = i + 1;
                FileName = $"{BaseFileName}({i})";
            }

            TextWriter writer = new StreamWriter($@"{ChildFormConfig.GetMapsetPath()}/{FileName}.osu", true);

            foreach (var lines in template)
            {
                writer.WriteLine(lines);
            }
            writer.Close();
        }

        public static List<string> mergeLists(List<List<string>> input, bool IsItTimingPoint)
        {
            List<string> Merged = new List<string>();

            foreach (var file in input)
            {
                Merged.AddRange(file);
            }

            sort(Merged, IsItTimingPoint, 0, Merged.Count - 1);

            return Merged;
        }

        private static void sort(List<string> input, bool IsItTimingPoint, int lo, int hi) // https://en.wikipedia.org/wiki/Quicksort
        {
            if (lo < hi)
            {
                int pi = Partition(input, lo, hi, IsItTimingPoint);
                sort(input, IsItTimingPoint, lo, pi - 1);
                sort(input, IsItTimingPoint, pi + 1, hi);
            }
        }

        private static int Partition(List<string> input, int lo, int hi, bool IsItTimingPoint)
        {
            int pivot = ConvertLineToOffset(input[hi], IsItTimingPoint);
            int i = lo - 1;

            for (int j = lo; j < hi; j = j + 1)
            {
                if (ConvertLineToOffset(input[j], IsItTimingPoint) < pivot)
                {
                    i = i + 1;

                    string temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                }
            }

            string temp2 = input[i + 1];
            input[i + 1] = input[hi];
            input[hi] = temp2;

            return i + 1;
        }

        private static int ConvertLineToOffset(string input, bool IsItTimingPoint)
        {
            int offset = 0;
            string[] tempArray = input.Split(',');
            if (IsItTimingPoint)
            {
                offset = Convert.ToInt32(tempArray[0]);
            }
            else
            {
                offset = Convert.ToInt32(tempArray[2]);
            }
            return offset;
        }

        #endregion for merging the final things only

        
        
    }
}