using Newtonsoft.Json;
using OsuHelperTool.Classes.Miscellaneous.Main_buttons;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Main
{
    internal class ChildFormConfig
    {
        private static Color[] ColorArray;

        private static Control MainInterface;

        public static void SetColorToken(Color[] input)
        {
            ColorArray = input;
        }

        public static void SetMainInterface(Control input)
        {
            MainInterface = input;
        }



        
        public static void ReloadChildform(Form childForm,Form newChildForm)
        {

            childForm.Close();
            newChildForm.TopLevel = false;
            newChildForm.FormBorderStyle = FormBorderStyle.None;
            newChildForm.Dock = DockStyle.Fill;
            MainInterface.Controls.Add(newChildForm);
            MainInterface.Tag = newChildForm;
            newChildForm.Show();
        }

        public static string GetMapsetPath()
        {
            string check = File.ReadAllText(@"Preferences.json");
            var JsonConfigs = JsonConvert.DeserializeObject<ConfigJson>(check);
            
            return JsonConfigs.GetCurrentPath();
        }

        public static Color GetMiscObjectColor()
        {
            return ColorArray[0];
        }

        public static Color GetMainButtonColor()
        {
            return ColorArray[1];
        }

        public static Color GetSubButtonColor()
        {
            return ColorArray[2];
        }

        public static Color GetBackColor()
        {
            return ColorArray[3];
        }
    }
}