using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Main.Merger
{
    public partial class Bpm_Offset_ErrorMessageBox : Form
    {
        private List<string> FileNames;
        private List<List<string>> TimingPanel;
        private List<List<string>> UninheritedPoints;
        private List<int> NumOfUPInFileList;

        private List<string> RefrenceFiles = new List<string>();

        public List<List<string>> newTimingPanel { get; set; }

        public Bpm_Offset_ErrorMessageBox(List<List<string>> InputTimingPanel, List<List<string>> InputUninheritedPoints, List<string> InputFileNames, List<int> InputNumOfUPInFileList, Exception Msg)//List<List<string>> input, List<string> FileNamesInput, Exception Msg)
        {
            InitializeComponent();
            FileNames = InputFileNames;
            ErrorMsg.Text = Msg.Message;
            TimingPanel = InputTimingPanel;
            NumOfUPInFileList = InputNumOfUPInFileList;
            UninheritedPoints = InputUninheritedPoints;
        }

        private void Bpm_Offset_ErrorMessageBox_Load(object sender, EventArgs e)
        {
            List<string[,]> seperated = new List<string[,]>();
            foreach (int NumOfUP in NumOfUPInFileList)
            {
                string[,] a = new string[2, NumOfUP];
                seperated.Add(a);
            }

            #region mistake

            /*
            int MaxIndex = 0;
            int PreviousIndex = 0;
            for (int i = 0; i < FileNames.Count; i = i + 1)
            {
                MaxIndex = MaxIndex + seperated[i].GetLength(1);

                for (int x = 0; x < seperated[i].GetLength(1); x = x + 1)
                {
                    for (int y = PreviousIndex; y < MaxIndex; y = y + 1)
                    {
                        for (int z = 0; z < 2; z = z + 1)
                        {
                            seperated[i][z, x] = UninheritedPoints[y][z];
                        }
                    }
                }

                PreviousIndex = seperated[i].GetLength(1);
            }
            */

            #endregion mistake

            //colum = vertical row = horizontal

            int MaxIndex = 0;
            int PreviousIndex = 0;

            for (int i = 0; i < FileNames.Count; i = i + 1)
            {
                MaxIndex = MaxIndex + seperated[i].GetLength(1);
                for (int y = PreviousIndex; y < MaxIndex;)
                {
                    for (int x = 0; x < seperated[i].GetLength(1); x = x + 1, y = y + 1)
                    {
                        for (int z = 0; z < seperated[i].GetLength(0); z = z + 1)
                        {
                            seperated[i][z, x] = UninheritedPoints[y][z];
                        }
                    }
                }
                PreviousIndex = seperated[i].GetLength(1);
            }

            for (int i = 0; i < seperated.Count; i = i + 1)
            {
                for (int y = 0; y < seperated[i].GetLength(1); y = y + 1)
                {
                    CLBSelectToDelete.Items.Add($"Offset at:({seperated[i][0, y]}) at {1 / Convert.ToDouble(seperated[i][1, y]) * 1000 * 60} bpm from {FileNames[i]}", false);
                    RefrenceFiles.Add(FileNames[i]);
                }
            }
        }

        // CLBSelectToDelete.Items.Add($"Offset at:({list[i][y]}) from {FileNames[i]}", false);

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
            newTimingPanel = TimingPanel;
        }

        private void DeleteSelected_Click(object sender, EventArgs e)
        {
            List<List<string>> SelectToDelete = new List<List<string>>();
            for (int i = 0; i < CLBSelectToDelete.Items.Count; i = i + 1)
            {
                List<string> temp = new List<string>();
                if (CLBSelectToDelete.GetItemCheckState(i) == CheckState.Checked)
                {
                    temp.Add(RefrenceFiles[i]);
                    temp.Add(UninheritedPoints[i][0]);
                    temp.Add(UninheritedPoints[i][1]);
                    SelectToDelete.Add(temp);
                }
            }

            List<int> File = new List<int>();

            string PreviousFile = SelectToDelete[0][0];
            int count = 0;

            for (int i = 0; i < SelectToDelete.Count; i = i + 1)
            {
                if (PreviousFile == SelectToDelete[i][0])
                {
                    File.Add(count);
                    PreviousFile = SelectToDelete[i][0];
                }
                else
                {
                    count = count + 1;
                    File.Add(count);
                    PreviousFile = SelectToDelete[i][0];
                }
            }

            List<List<string>> Temp = TimingPanel;

            foreach (var item in File)
            {
                for (int i = 0; i < Temp[item].Count; i = i + 1)
                {
                    string[] split = Temp[item][i].Split(',');

                    string[] ValueToSearch = new string[2] { split[0], split[1] };

                    for (int y = 0; y < SelectToDelete.Count; y = y + 1)
                    {
                        if (ValueToSearch[0] == SelectToDelete[y][1] && ValueToSearch[1] == SelectToDelete[y][2])
                        {
                            Temp[item].RemoveAt(i);
                            break;
                        } 
                    }
                }
            }

            newTimingPanel = Temp;
        }
    }
}