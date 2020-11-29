using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Main.Merger
{
    public partial class Bpm_Offset_ErrorMessageBox : Form
    {
        private List<string> FileNames;
        private List<List<string>> TimingPointsLists;
        private List<List<string>> UninheritedPoints;
        

        private List<string> RefrenceFiles = new List<string>();

        public List<List<string>> newTimingPoint { get; set; }

        public Bpm_Offset_ErrorMessageBox(List<List<string>> InputTimingPointsLists, List<List<string>> InputUninheritedPoints, List<string> InputFileNames)
        {
            InitializeComponent();
            FileNames = InputFileNames;
            
            TimingPointsLists = InputTimingPointsLists;
            
            UninheritedPoints = InputUninheritedPoints;
        }

        //UP List index => OFFSET, BPM, FILE NUM

        private void Bpm_Offset_ErrorMessageBox_Load(object sender, EventArgs e)
        {
            

            foreach(var UP in UninheritedPoints)
            {
                CLBSelectToDelete.Items.Add($"Offset at:({UP[0]}) at {1 / Convert.ToDouble(UP[1]) * 1000 * 60} bpm from {FileNames[Convert.ToInt32(UP[2])]}", false);
                RefrenceFiles.Add(FileNames[Convert.ToInt32(UP[2])]);
            }

        }

       

        private void CLBSelectToDelete_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    string s = CLBSelectToDelete.SelectedItem.ToString();
                    string[] temp = s.Split('(');
                    string[] temp2 = temp[1].Split(')');
                    string copyText = temp2[0];

                    Clipboard.SetText(copyText);
                }
            }
            catch
            {
                MessageBox.Show("Please select an Item first.");
            }
        }

        private void ContinueWithoutDelete_Click(object sender, EventArgs e)
        {
            newTimingPoint = TimingPointsLists;
        }

        private void DeleteSelected_Click(object sender, EventArgs e)
        {
            List<List<string>> SelectToDelete = new List<List<string>>();
            for (int i = 0; i < CLBSelectToDelete.Items.Count; i = i + 1)
            {
                List<string> temp = new List<string>();
                if (CLBSelectToDelete.GetItemCheckState(i) == CheckState.Checked)
                {
                    temp.Add(UninheritedPoints[i][0]);
                    temp.Add(UninheritedPoints[i][1]);
                    temp.Add(RefrenceFiles[i]);
                    
                    SelectToDelete.Add(temp);
                }
            }
            List<int> FileNum = new List<int>();

            string PreviousFile = SelectToDelete[0][0];
            int count = 0;

            for (int i = 0; i < SelectToDelete.Count; i = i + 1)
            {
                if (PreviousFile == SelectToDelete[i][2])
                {
                    FileNum.Add(count);
                    PreviousFile = SelectToDelete[i][2];
                }
                else
                {
                    count = count + 1;
                    FileNum.Add(count);
                    PreviousFile = SelectToDelete[i][2];
                }
            }

            List<List<string>> newTimingPointsLists = TimingPointsLists;

            foreach (int Num in FileNum)
            {
                for (int i = 0; i < newTimingPointsLists[Num].Count; i = i + 1)
                {
                    string[] split = newTimingPointsLists[Num][i].Split(',');

                    string[] ValueToSearch = new string[2] { split[0], split[1] };

                    for (int y = 0; y < SelectToDelete.Count; y = y + 1)
                    {
                        if (ValueToSearch[0] == SelectToDelete[y][0] && ValueToSearch[1] == SelectToDelete[y][1])
                        {
                            newTimingPointsLists[Num].RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            newTimingPoint = newTimingPointsLists;
            
            



        }
    }
}