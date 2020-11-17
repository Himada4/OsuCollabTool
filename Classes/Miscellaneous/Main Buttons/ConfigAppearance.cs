using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OsuHelperTool.Classes.Main;

namespace OsuHelperTool.Classes.Miscellaneous.Main_buttons
{
    class ConfigAppearance
    {
        private Form form;
        private Color[] Theme;
        
        private Control[] FormBorder;
        private Control Background;
        private string Orientation;

        public ConfigAppearance()
        {
            
        }

        public void SetTheme(Form inputForm ,Color[] inputTheme, Control inputBackground, string inputOrientation,params Control[] inputFormBorder)
        {
            Theme = inputTheme;

            FormBorder = inputFormBorder;
            Background = inputBackground;
            Orientation = inputOrientation;

            form = inputForm;
        }

        public void SetChildFormTheme(Color[]  inputTheme)
        {
            ChildFormConfig.SetColorToken(inputTheme);
        } 

        public void ApplyTheme()
        {
            foreach (Control control in FormBorder)
            {
                control.BackColor = Theme[0];
            }

            Background.BackColor = Theme[3];
        }


        public void ApplyOrientation()
        {
            if(Orientation == "1")
            {
                form.Width = 903;
                form.Height = 548;
            }
            else
            {
                form.Width = 412;
                form.Height = 453;
            } 
        }
        

    }
}
