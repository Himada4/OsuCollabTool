using Newtonsoft.Json;
using OsuHelperTool.Classes.Common;
using OsuHelperTool.Classes.Main;
using OsuHelperTool.Classes.Miscellaneous.Main_buttons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Miscellaneous
{
    public partial class PreferencesForm : Form
    {
        private Form form;
        private Draggable _move;
        

        
        private string newCurrentFolder;

        
        private string oldCurrentFolder;


        public PreferencesForm(Form inputForm)
        {
            InitializeComponent();
            _move = new Draggable(this, FormBorder.Size.Height);
            _move.SetMovable(FormBorder);
            form = inputForm;

            

             


            string check = File.ReadAllText(@"Preferences.json");
            var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);

            
            oldCurrentFolder = JsonConfigs.GetCurrentPath();

            MapsetPathTextBox.Text = oldCurrentFolder;

            if (JsonConfigs.GetOrientation() == "1")
            {
                Horizontal.Checked = true;
            }
            else
            {
                SqareMini.Checked = true;
            }

            List<int> BO = MainScreen.JsonButtonOrderToList(JsonConfigs.GetButtonOrder());

            for (int i = 0; i < BO.Count; i = i + 1)
            {
                switch (i)
                {
                    case 0:
                        numericUpDown1.Value = BO[i];
                        break;

                    case 1:
                        numericUpDown2.Value = BO[i];
                        break;
                    case 2:
                        numericUpDown3.Value = BO[i];
                        break;
                    case 3:
                        numericUpDown4.Value = BO[i];
                        break;
                }
            }

            Color[] colors = JsonConfigs.GetColorArray();

            for (int i = 0; i < colors.Length; i = i + 1)
            {
                switch (i)
                {
                    case 0:
                        FormBorderTextBox.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                     colors[i].R,
                     colors[i].G,
                     colors[i].B);
                        PreviewFormBorder.BackColor = Color.FromArgb(colors[i].ToArgb());
                        break;

                    case 1:
                        MainButtonColorTextbox.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                      colors[i].R,
                      colors[i].G,
                      colors[i].B);
                        PreviewMainButtons.BackColor = Color.FromArgb(colors[i].ToArgb());
                        break;
                    case 2:
                        SubButtonColorTextBox.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                     colors[i].R,
                     colors[i].G,
                     colors[i].B);
                        PreviewSubButtons.BackColor = Color.FromArgb(colors[i].ToArgb());
                        break;
                    case 3:
                        BackgroundColorTextbox.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                     colors[i].R,
                     colors[i].G,
                     colors[i].B);
                        PreviewBackground.BackColor = Color.FromArgb(colors[i].ToArgb());
                        break;
                }
            }
            
            
            
            
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
        }

        private  void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //form.Enabled = true;
            
        }

       

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenPathFinder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                
                string check = File.ReadAllText(@"Preferences.json");
                var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);

                fd.SelectedPath = oldCurrentFolder;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    MapsetPathTextBox.Text = fd.SelectedPath;
                    newCurrentFolder = fd.SelectedPath;
                }

                int filesFound = 0;
                string[] files = Directory.GetFiles(fd.SelectedPath);

                foreach (string file in files)
                {
                    if (file.Contains(".osu"))
                    {
                        filesFound = filesFound + 1;
                    }
                }
                Exceptions.CheckNumOfFiles(filesFound);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MapsetPathTextBox.Text = "";
            }
        }

        private void SavePreferences_Click(object sender, EventArgs e)
        {
            try
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                NumericUpDown[] controls = new NumericUpDown[]
                {
                    numericUpDown1,numericUpDown2,numericUpDown3,numericUpDown4
                };

                for (int i = 0; i < controls.Length; i = i + 1)
                {
                    switch (controls[i].Value)
                    {
                        case 1:
                            one = true;
                            break;
                        case 2:
                            two = true;
                            break;
                        case 3:
                            three = true;
                            break;
                        case 4:
                            four = true;
                            break;
                    }
                }

                if(one && two && three && four)
                {
                     #region sunny case
                    string orientation = "";
                    ConfigJson config = new ConfigJson();
                    config.SetTheme(new Color[] { ColorTranslator.FromHtml(FormBorderTextBox.Text), ColorTranslator.FromHtml(MainButtonColorTextbox.Text), ColorTranslator.FromHtml(SubButtonColorTextBox.Text), ColorTranslator.FromHtml(BackgroundColorTextbox.Text) });
                    config.SetButtonOrder($"{numericUpDown1.Value},{numericUpDown2.Value},{numericUpDown3.Value},{numericUpDown4.Value}");
                    config.SetCurrentPath(MapsetPathTextBox.Text);
                    if (Horizontal.Checked == true)
                    {
                        orientation = "1";
                    }
                    else
                    {
                        orientation = "0";
                    }
                    config.SetOrientation(orientation);
                    
                    string str = JsonConvert.SerializeObject(config);
                    File.WriteAllText(@"Preferences.json", str);
                    #endregion

                    MessageBox.Show("Settings saved. Please restart the program to have its effect.");
                }
                else
                {
                    throw new Exception("Please arrange the button order appropriately.");
                }




                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        #region mistake
        /*
 * ConfigJson configJson = new ConfigJson()
   {
       Theme = new Color[4] { ColorTranslator.FromHtml("#111111"), ColorTranslator.FromHtml("#222222"), ColorTranslator.FromHtml("#222222"), ColorTranslator.FromHtml("#222222") },

       ButtonOrder = "1,2,3,4"
   };

   string str = JsonConvert.SerializeObject(configJson);
   File.WriteAllText(@"Preferences.json",str);
   
 */
        #endregion


        #region theme selection
        private void FormBorderColorButton_Click(object sender, EventArgs e)
        {
            HexCodeColorPick(FormBorderTextBox, PreviewFormBorder); 
            
        }

        private void MainButtonColorbutton_Click(object sender, EventArgs e)
        {
            HexCodeColorPick(MainButtonColorTextbox,PreviewMainButtons);
            
        }

        private void SubButtoncolorbutton_Click(object sender, EventArgs e)
        {
            HexCodeColorPick(SubButtonColorTextBox,PreviewSubButtons);
            
        }

        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            HexCodeColorPick(BackgroundColorTextbox,PreviewBackground);
            
        }

        private void HexCodeColorPick(TextBox textBox, Button button)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                     colorDialog1.Color.R,
                     colorDialog1.Color.G,
                     colorDialog1.Color.B);
            }
            Color color = ColorTranslator.FromHtml(textBox.Text);
            button.BackColor = color;
        }

        #endregion


    }
}