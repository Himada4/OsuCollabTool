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
        private List<List<string>> PUninheritedPoints = new List<List<string>>();
        private List<int> PNumOfUPInFileList = new List<int>();

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
                    Task<Exception> task = new Task<Exception>(CheckMergeErrors);
                    task.Start();

                    MergeButton.Text = "Processing...";
                    Exception a = await task;
                    if(a == Exceptions.CancelOperation)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private Exception CheckMergeErrors()
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

            #region gets timing panels VAR = TimingPanels

            List<List<string>> TimingPanels = new List<List<string>>();

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

                TimingPanels.Add(List);

                //close the file
                sr.Close();
            }

            #endregion gets timing panels VAR = TimingPanels

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

            #region find possible errors *ONLY DEALS WITH TIMING PANELS*

            Exception exceptions = FindBpmErrors(TimingPanels); //returns the possible errors of having unique bpms or offsets

            List<List<string>> FinalTimingPoint = new List<List<string>>();
            List<List<string>> FinalHitObjects = new List<List<string>>();

            Exception operationCancelled = new Exception();
            

            if (exceptions != null) // if problem found,  from https://www.youtube.com/watch?v=8aDsXyiBLsI&list=LL&index=5
            {
                using (Bpm_Offset_ErrorMessageBox EBox = new Bpm_Offset_ErrorMessageBox(TimingPanels,PUninheritedPoints,FilesForEMessageBox,PNumOfUPInFileList,exceptions))
                {
                    Invoke((Action)(() => { EBox.ShowDialog(); }));
                    if (EBox.DialogResult == DialogResult.Ignore)
                    {
                        FinalTimingPoint = EBox.newTimingPanel;
                        FinalHitObjects = HitObjects;
                        StartMerge(FinalHitObjects, FinalTimingPoint);
                        
                    }
                    else if (EBox.DialogResult == DialogResult.OK)
                    {
                        FinalTimingPoint = EBox.newTimingPanel;
                        FinalHitObjects = HitObjects;
                        StartMerge(FinalHitObjects, FinalTimingPoint);

                    }
                    else
                    {
                        operationCancelled = Exceptions.CancelOperation;
                    }
                }
            }

            #endregion find possible errors *ONLY DEALS WITH TIMING PANELS*

            //MergeLists(TimingPanels, true);
            //MergeLists(HitObjects, false);

            return operationCancelled;
            // }
            // catch (Exception ex)
            // {
            //     if (ex == null)
            //    {
            //        return false;
            //    }

            //    return false;
            //}
        }

        private void StartMerge(List<List<string>> HitObjects, List<List<string>> TimingPanels)
        {
            List<string> FinalHitObjects = mergeLists(HitObjects, false);
            List<string> FinalTimingPanels = mergeLists(TimingPanels, true);

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

            foreach (var lines in FinalTimingPanels)
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


        public static List<string> mergeLists(List<List<string>> input, bool IsItTimingPanel)
        {
            List<string> Merged = new List<string>();

            foreach (var file in input)
            {
                Merged.AddRange(file);
            }

            sort(Merged, IsItTimingPanel, 0, Merged.Count - 1);


            return Merged;
        }

        private static void sort(List<string> input, bool IsItTimingPanel, int lo, int hi) // https://en.wikipedia.org/wiki/Quicksort
        {
     
            if (lo < hi)
            {
                int pi = Partition(input, lo, hi, IsItTimingPanel);
                sort(input, IsItTimingPanel, lo, pi - 1);
                sort(input, IsItTimingPanel, pi + 1, hi);
            }

        }

        private static int Partition(List<string> input, int lo, int hi, bool IsItTimingPanel)
        {
            
            int pivot = ConvertLineToOffset(input[hi], IsItTimingPanel);
            int i = lo - 1;

            for (int j = lo; j < hi; j = j + 1)
            {
                if (ConvertLineToOffset(input[j], IsItTimingPanel) < pivot)
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

        private static int ConvertLineToOffset(string input, bool IsItTimingPanel)
        {
            int offset = 0;
            string[] tempArray = input.Split(',');
            if (IsItTimingPanel)
            {
                offset = Convert.ToInt32(tempArray[0]);
            }
            else
            {
                offset = Convert.ToInt32(tempArray[2]);
            }
            return offset;
        }




        private Exception FindBpmErrors(List<List<string>> TimingPanels)
        {
            Exception error = new Exception();

            List<List<string>> UninheritedPoints = new List<List<string>>();

            List<int> NumOfUPInFileList = new List<int>();

            

            foreach (var item in TimingPanels)
            {
                int NumOfUPInFile = 0;
                for (int i = 0; i < item.Count; i = i + 1)
                {
                    string[] split = item[i].Split(',');

                    List<string> Temp = new List<string>();

                    if (!split[1].Contains("-"))
                    {
                        Temp.Add(split[0]);
                        Temp.Add(split[1]);
                        UninheritedPoints.Add(Temp);
                        NumOfUPInFile = NumOfUPInFile + 1;
                    }
                }
                NumOfUPInFileList.Add(NumOfUPInFile);
            }

            foreach (var item in UninheritedPoints)
            {
                if (DecisionSelfLoop(item, UninheritedPoints))
                {
                    error = Exceptions.INHERITANCE_ERROR;
                }
            }

            PUninheritedPoints = UninheritedPoints;
            PNumOfUPInFileList = NumOfUPInFileList;

            #region mistakes

            /*

            #region bpm

            List<List<string>> BPMs = TimingPanelBpm(TimingPanels);

            List<string> MergedBpms = new List<string>();
            foreach (var bpm in BPMs)
            {
                MergedBpms.AddRange(bpm);
            }

            foreach (var bpm in MergedBpms)
            {
                if (!DecisionSelfLoop(bpm, MergedBpms))
                {
                    error.Add(Exceptions.BPM_ERROR);
                }
            }

            #endregion bpm

            #region offset

            List<List<string>> Offsets = TimingPanelOffset(TimingPanels);
            List<string> MergedOffsets = new List<string>();
            foreach (var offset in Offsets)
            {
                MergedOffsets.AddRange(offset);
            }

            foreach (var item in MergedOffsets)
            {
                if (!DecisionSelfLoop(item, MergedOffsets))
                {
                    error.Add(Exceptions.OFFSET_ERROR);
                }
            }

            #endregion offset

            */

            #endregion mistakes

            if (error != Exceptions.INHERITANCE_ERROR)
            {
                error = null;
            }

            return error;
        }

        private bool DecisionSelfLoop(List<string> inputToFind, List<List<string>> inputToLoop)
        {
            int found = 0;
            foreach (var item in inputToLoop)
            {
                if (inputToFind[0] == item[0] && inputToFind[1] == item[1])
                {
                    found = found + 1;
                }
            }
            bool errorFound = true;
            if (MergeList.Items.Count % 2 == 1)
            {
                if(found % 2 == 1)
                {
                    errorFound = false;
                } 
            }
            else
            {
                if (found % 2 == 0)
                {
                    errorFound = false;
                }
            }
            
            if(found == 1)
            {
                errorFound = true;
            }
            
            return errorFound;
        }

        
    }
}