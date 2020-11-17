using Newtonsoft.Json;
using OsuHelperTool.Classes.Common;
using OsuHelperTool.Classes.Miscellaneous;
using OsuHelperTool.Classes.Miscellaneous.Main_buttons;
using OsuHelperTool.Classes.Miscellaneous.Main_Buttons;
using OsuHelperTool.Classes.Main.Merger;
using OsuHelperTool.Classes.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace OsuHelperTool
{
    public partial class MainScreen : Form
    {
        private Draggable _move;
        private List<int> ButtonOrderToken;
        private Color[] ColorArrayToken;
        private string CurrentPath;
        private string Orientation;

        private List<Control> ButtonList1 = new List<Control>();
        private List<Control> ButtonList2 = new List<Control>();
        private List<Control> ButtonList3 = new List<Control>();
        private List<Control> ButtonList4 = new List<Control>();
        Button PreviousButton;
        int counter = 0;
        
        
        private List<Control> TempEdited1 = new List<Control>();
        private List<Control> TempEdited2 = new List<Control>();
        private List<Control> TempEdited3 = new List<Control>();
        private List<Control> TempEdited4 = new List<Control>();
        



        

        public MainScreen()
        {
            InitializeComponent();
            _move = new Draggable(this, FormBorder.Size.Height);
            _move.SetMovable(FormBorder, ProjectNameLabel);

            refreshCheckJsonFile();

            PopulateMainTableLayout();

            PopulateSubTableLayout();

            List<List<Control>> TempLists = new List<List<Control>>(){ ButtonList1,ButtonList2,ButtonList3,ButtonList4};

            List<List<Control>> TempEditedLists = new List<List<Control>>() { TempEdited1, TempEdited2, TempEdited3, TempEdited4 };

            for (int i = 0; i < TempLists.Count; i = i + 1)
            {
                foreach(var item in TempLists[i])
                {
                    if(item.Tag == null)
                    {
                        TempEditedLists[i].Add(item);
                    }
                }
            }

            ConfigAppearance config = new ConfigAppearance();

            config.SetTheme(this, ColorArrayToken, this, Orientation,FormBorder, InfoButton, CloseButton, MinimiseButton, PreferencesButton);

            config.ApplyTheme();

            config.SetChildFormTheme(ColorArrayToken);

            config.ApplyOrientation();

            ChildFormConfig.SetMainInterface(Interface);
        }

        private void refreshCheckJsonFile()
        {
            
            string check = File.ReadAllText(@"Preferences.json");
            var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);
            ButtonOrderToken = JsonButtonOrderToList(JsonConfigs.GetButtonOrder());
            ColorArrayToken = JsonConfigs.GetColorArray();
            CurrentPath = JsonConfigs.GetCurrentPath();
            Orientation = JsonConfigs.GetOrientation();
            
        }

        

        #region Program Setup

        public static List<int> JsonButtonOrderToList(string input)
        {
            string ButtonOrderToken = input;
            string[] num = ButtonOrderToken.Split(',');

            var resultList = new List<int>();

            foreach (var n in num)
            {
                resultList.Add(Convert.ToInt32(n));
            }

            return resultList;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void PreferencesButton_Click(object sender, EventArgs e)
        {
            Form form = new PreferencesForm(this);

            //this.Enabled = false;
            form.ShowDialog();

        }

        

        private void InfoButton_Click(object sender, EventArgs e)
        {
            Form form = new InformationForm(this);
            this.Enabled = false;
            form.Show();
        }

        private void PopulateMainTableLayout() // credit: https://stackoverflow.com/questions/34426888/dynamic-button-creation-placing-them-in-a-predefined-order-using-c-sharp
        {
            for (int i = 0; i < MainButtonTableLayoutPanel.ColumnCount; i = i + 1)
            {
                var b = new Button();
                b.Tag = ButtonOrderToken[i];
                switch (i + 1)
                {
                    case 1:
                        b.Text = "Collab Tool";
                        break;

                    case 2:
                        b.Text = "Hitsound Tool";
                        break;

                    case 3:
                        b.Text= "Map Setup Tool";
                        break;

                    case 4:
                        b.Text = "Mapping Tool";
                        break;
                }
                //b.Text = CommonMethods.FuncName(ButtonOrderToken[i]);
                //b.Text = ButtonOrderToken[i].ToString(); //(i + 1).ToString();
                //b.Name = string.Format("b_{0}", i + 1);
                //b.Name = ButtonOrderToken[i].ToString();
                b.Margin = new Padding(0, 0, 0, 0);
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = ColorArrayToken[1];
                b.Dock = DockStyle.Fill;
                b.Click += new EventHandler(MainButton_Click);
                switch (b.Tag)
                {
                    case 1:
                        MainPanel1.Controls.Add(b);
                        break;

                    case 2:
                        MainPanel2.Controls.Add(b);
                        break;

                    case 3:
                        MainPanel3.Controls.Add(b);
                        break;

                    case 4:
                        MainPanel4.Controls.Add(b);
                        break;
                }
                AddToButtonList(b, Convert.ToInt32(b.Tag));
            }
        }

        private void PopulateSubTableLayout()
        {
            SubButtons Collab = new SubButtons() // credit https://www.youtube.com/watch?v=fMjt6ywaSow
            {
                ID = ButtonOrderToken[0], //Merge Tool
                //NumberOfFunc = 3,
                FuncNames = new List<string>() { "Merge Tool", "Compare Version", "Map Seperator Tool" }
            };
            SubButtons Hitsound = new SubButtons()
            {
                ID = ButtonOrderToken[1], //Hitsound Tool
                //NumberOfFunc = 2,
                FuncNames = new List<string>() { "Volume Tool", "Hitsound Editor" }
            };
            SubButtons Setup = new SubButtons()
            {
                ID = ButtonOrderToken[2], // Setup Tool
                //NumberOfFunc = 4,
                FuncNames = new List<string>() { "Song Setup", "Bpm Detector Tool", "Note Shifter/Snapper", "Tips" }
            };
            SubButtons Mapping = new SubButtons()
            {
                ID = ButtonOrderToken[3], // Mapping Tool
                //NumberOfFunc = 1,
                FuncNames = new List<string>() { "Slider Art Generator" }
            };

            Dictionary<int, SubButtons> SubButton = new Dictionary<int, SubButtons>();

            SubButton.Add(Collab.ID, Collab);
            SubButton.Add(Hitsound.ID, Hitsound);
            SubButton.Add(Setup.ID, Setup);
            SubButton.Add(Mapping.ID, Mapping);

            foreach (KeyValuePair<int, SubButtons> key in SubButton)
            {
                SubButtons button = key.Value;
                switch (button.ID)
                {
                    case 1:
                        SpawnSubButtons(TableMenu1, button.FuncNames, button.ID);
                        break;

                    case 2:
                        SpawnSubButtons(TableMenu2, button.FuncNames, button.ID);
                        break;

                    case 3:
                        SpawnSubButtons(TableMenu3, button.FuncNames, button.ID);
                        break;

                    case 4:
                        SpawnSubButtons(TableMenu4, button.FuncNames, button.ID);
                        break;
                }
            }

            /*
             for (int i = 0; i < SubButtonLayoutTableHolder.ColumnCount; i = i + 1)
            {
                for (int y = 0; y < TableMenu1.RowCount; y = y + 1)
                {
                }
            }
            */
        }

        private void SpawnSubButtons(TableLayoutPanel control, List<string> funcNames, int ID)
        {
            for (int i = 0; i < funcNames.Count; i = i + 1)
            {
                Button b = new Button();
                //if (i == 0) { b.Margin = new Padding(0, 0, 0, 1); } else { b.Margin = new Padding(0, 1, 0, 1); }
                b.Margin = new Padding(0, 0, 0, 0);
                b.Text = funcNames[i];
                b.Name = funcNames[i];
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = ColorArrayToken[2];
                b.Dock = DockStyle.Fill;
                b.Tag = null;
                b.Click += new EventHandler(SubButton_Click);
                control.Controls.Add(b);
                b.Visible = false;
                AddToButtonList(b, ID);
            }
        }

        private void AddToButtonList(Control b, int ID)
        {
            switch (ID)
            {
                case 1:
                    ButtonList1.Add(b);
                    break;

                case 2:
                    ButtonList2.Add(b);
                    break;

                case 3:
                    ButtonList3.Add(b);
                    break;

                case 4:
                    ButtonList4.Add(b);
                    break;
            }
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            try
            {
                string check = File.ReadAllText(@"Preferences.json");
                var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);
                CurrentPath = JsonConfigs.GetCurrentPath();

                if (CurrentPath == "" || CurrentPath == null)
                {
                    throw Exceptions.NoMapsetPath;
                }
                if (counter == 0)
                {
                    PreviousButton = (Button)sender;
                }
                counter = counter + 1;
                Button selectedButton = (Button)sender;
                Interface.SendToBack();

                if (Interface.Controls.Count == 1)
                {
                    Interface.SendToBack();
                }





                switch (selectedButton.Text)
                {
                    case "Collab Tool":
                        MakeVisiblilityTrue(search(false, "Collab Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        MakeVisibilityFalse(search(true, "Collab Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        break;
                    case "Hitsound Tool":
                        MakeVisiblilityTrue(search(false, "Hitsound Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        MakeVisibilityFalse(search(true, "Hitsound Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        break;
                    case "Map Setup Tool":
                        MakeVisiblilityTrue(search(false, "Map Setup Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        MakeVisibilityFalse(search(true, "Map Setup Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        break;
                    case "Mapping Tool":
                        MakeVisiblilityTrue(search(false, "Mapping Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        MakeVisibilityFalse(search(true, "Mapping Tool", ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray()));
                        break;
                }

                if (counter == 2 && PreviousButton == (Button)sender)
                {
                    MakeVisibilityFalse(TempEdited1.ToArray(), TempEdited2.ToArray(), TempEdited3.ToArray(), TempEdited4.ToArray());
                    counter = 0;
                    Interface.BringToFront();

                }
                else
                {
                    if (PreviousButton != (Button)sender)
                    {
                        counter = 0;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

            #region mistake
            /*
            try
            {
                string check = File.ReadAllText(@"Preferences.json");
                var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);
                CurrentPath = JsonConfigs.GetCurrentPath();

                if (CurrentPath == "" || CurrentPath == null)
                {
                    throw NoMapsetPath;
                }
                if (counter == 0)
                {
                    PreviousButton = (Button)sender;
                }
                counter = counter + 1;
                Button selectedButton = (Button)sender;
                Interface.SendToBack();
                List<Control> Temp1 = ButtonList1;
                List<Control> Temp2 = ButtonList2;
                List<Control> Temp3 = ButtonList3;
                List<Control> Temp4 = ButtonList4;

                List<Control> Edited1 = new List<Control>();
                List<Control> Edited2 = new List<Control>();
                List<Control> Edited3 = new List<Control>();
                List<Control> Edited4 = new List<Control>();

                List<int> testBOT = ButtonOrderToken;



                if (Interface.Controls.Count == 1)
                {
                    Interface.SendToBack();
                }

                for (int i = 0; i < testBOT.Count; i = i + 1)
                {
                    switch (testBOT[i])
                    {
                        case 1:
                            Edited1 = search(testBOT[i], Temp1.ToArray(), Temp2.ToArray(), Temp3.ToArray(), Temp4.ToArray());
                            break;

                        case 2:
                            Edited2 = search(testBOT[i], Temp1.ToArray(), Temp2.ToArray(), Temp3.ToArray(), Temp4.ToArray());
                            break;

                        case 3:
                            Edited3 = search(testBOT[i], Temp1.ToArray(), Temp2.ToArray(), Temp3.ToArray(), Temp4.ToArray());
                            break;

                        case 4:
                            Edited4 = search(testBOT[i], Temp1.ToArray(), Temp2.ToArray(), Temp3.ToArray(), Temp4.ToArray());
                            break;
                    }
                }

                Edited1.RemoveAt(0);
                Edited2.RemoveAt(0);
                Edited3.RemoveAt(0);
                Edited4.RemoveAt(0);

                TempEdited1 = Edited1;
                TempEdited2 = Edited2;
                TempEdited3 = Edited3;
                TempEdited4 = Edited4;

                if (counter == 2 && PreviousButton == (Button)sender)
                {
                    MakeVisibilityFalse(Edited1.ToArray(), Edited2.ToArray(), Edited3.ToArray(), Edited4.ToArray());
                    counter = 0;
                    Interface.BringToFront();

                }
                else
                {
                    if (PreviousButton != (Button)sender)
                    {
                        counter = 0;
                    }
                    switch (Convert.ToInt32(selectedButton.Name))
                    {
                        case 1:
                            foreach (var item in Edited1)
                            {
                                item.Visible = true;
                                item.BringToFront();
                            }
                            MakeVisibilityFalse(Edited2.ToArray(), Edited3.ToArray(), Edited4.ToArray());
                            break;

                        case 2:
                            foreach (var item in Edited2)
                            {
                                item.Visible = true;
                                item.BringToFront();
                            }
                            MakeVisibilityFalse(Edited1.ToArray(), Edited3.ToArray(), Edited4.ToArray());
                            break;

                        case 3:
                            foreach (var item in Edited3)
                            {
                                item.Visible = true;
                                item.BringToFront();
                            }
                            MakeVisibilityFalse(Edited1.ToArray(), Edited2.ToArray(), Edited4.ToArray());
                            break;

                        case 4:
                            foreach (var item in Edited4)
                            {
                                item.Visible = true;
                                item.BringToFront();
                            }
                            MakeVisibilityFalse(Edited1.ToArray(), Edited2.ToArray(), Edited3.ToArray());
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
            #endregion
        }

        private Control[] search(bool Invis, string valueToLookFor, params Control[][] input)
        {
            List<Control> result = new List<Control>();
            
            foreach(var item in input)
            {
                if (!Invis)
                {
                    if (item[0].Text == valueToLookFor)
                    {
                        for (int i = 1; i < item.Length; i = i + 1)
                        {
                            result.Add(item[i]);
                        }
                    }
                }
                else
                {
                    if(item[0].Text != valueToLookFor)
                    {
                        for (int i = 1; i < item.Length; i = i + 1)
                        {
                            result.Add(item[i]);
                        }
                    }
                }
            }

            return result.ToArray();
        }
        

        private void MakeVisibilityFalse(params Control[][] input)
        {
            for (int i = 0; i < input.Length; i = i + 1)
            {
                for (int y = 0; y < input[i].Length; y = y + 1)
                {
                    input[i][y].Visible = false;
                }
            }
        }

        private void MakeVisiblilityTrue(params Control[][] input)
        {
            for (int i = 0; i < input.Length; i = i + 1)
            {
                for (int y = 0; y < input[i].Length; y = y + 1)
                {
                    input[i][y].Visible = true;
                }
            }
        }

        #region tablemenuclick
        private void TableMenuMenuClick()
        {
            MakeVisibilityFalse(TempEdited1.ToArray(), TempEdited2.ToArray(), TempEdited3.ToArray(), TempEdited4.ToArray());
            counter = 0;
            Interface.BringToFront();
        }

        private void TableMenu4_MouseClick(object sender, MouseEventArgs e)
        {
            TableMenuMenuClick();
        }

        private void TableMenu3_MouseClick(object sender, MouseEventArgs e)
        {
            TableMenuMenuClick();
        }

        private void TableMenu2_MouseClick(object sender, MouseEventArgs e)
        {
            TableMenuMenuClick();
        }

        private void TableMenu1_MouseClick(object sender, MouseEventArgs e)
        {
            TableMenuMenuClick();
        }
        #endregion

        #endregion Program Setup

        private void SubButton_Click(object sender, EventArgs e)
        {
            Interface.Controls.Clear();

            Button selectedButton = (Button)sender;

            counter = counter - 1;

            MakeVisibilityFalse(TempEdited1.ToArray(), TempEdited2.ToArray(), TempEdited3.ToArray(), TempEdited4.ToArray());

            //MakeHeaderButtonVisibleTrue(ButtonList1.ToArray(), ButtonList2.ToArray(), ButtonList3.ToArray(), ButtonList4.ToArray());

            Interface.BringToFront();

            switch (selectedButton.Name)
            {
                case "Merge Tool":

                    MergerForm mergerForm = new MergerForm();

                    openChildForm(mergerForm);

                    break;
                case "a    ":

                    break;
                case "a   ":

                    break;
                case "a ":

                    break;
                case "a":

                    break;
                case "a      ":

                    break;
                case "a           ":

                    break;
                case "a             ":

                    break;
                case "a              ":

                    break;
                case "a        ":

                    break;
            }

            

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; 
            Interface.Controls.Add(childForm);
            Interface.Tag = childForm;
            childForm.Show();
        }

        
    }
}