using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Common
{
    class Exceptions
    {
        private static Exception NoFilesFound = new Exception("No valid .osu files were found. \n\t Please select an appropriate path.");
        public static void CheckNumOfFiles(int NumOfFiles)
        {
            if(NumOfFiles == 0)
            {
                throw NoFilesFound;
            } 
        }

        private static Exception EmptyInput = new Exception();

        public static void CheckInputEmpty(params Control[] control)
        {
            foreach (var item in control)
            {
                if (item.Text == "" || item.Text == null)
                {
                    throw EmptyInput;
                }
            }
        }

        public static Exception NoMapsetPath = new Exception("Please set the mapset path via preferences.");

        public static Exception CancelOperation = new Exception("Operation has been cancelled.");
    } 
}
