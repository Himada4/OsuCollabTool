using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using OsuHelperTool.Classes.Common;

namespace OsuHelperTool.Classes.Miscellaneous.Main_buttons
{
    class ConfigJson //credit: https://www.youtube.com/watch?v=NX3Um9E-AY0
    {
        public Color[] Theme  { get; set; }
        public string ButtonOrder { get; set; }
       

        public string CurrentPath { get; set; }

        public string Orientation { get; set; }



        public string GetButtonOrder()
        {
            return ButtonOrder.ToString();
        }

        public Color[] GetColorArray()
        {
            return Theme;
        } 

        public string GetCurrentPath()
        {
            return CurrentPath;
        } 

        public string GetOrientation()
        {
            return Orientation;
        } 


        public void SetTheme(Color[] input)
        {
            Theme = input;
        }
        public void SetButtonOrder(string input)
        {
            ButtonOrder = input;
        }
        

        public void SetCurrentPath(string input)
        {
            CurrentPath = input;
        }

        public void SetOrientation(string input)
        {
            Orientation = input;
        }



    }
}
