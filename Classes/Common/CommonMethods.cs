using System;
using System.Collections.Generic;

namespace OsuHelperTool.Classes.Common
{
    internal class CommonMethods
    {
        public static string ToString(List<int> input)
        {
            string result = "";

            foreach (int i in input)
            {
                result = result + input[i].ToString();
            }

            return result;
        }

        public static string ToString(int[] input)
        {
            string result = "";

            foreach (int i in input)
            {
                result = result + input[i].ToString();
            }

            return result;
        }

        



        /*
        public static List<string> SubFuncName(int input)
        {
            List<string> result;

            switch (input)
            {
                case 1:
                    result = new List<string>() { "Merge Tool", "Compare Version", "Map Seperator Tool" };
                    break;

                case 2:
                    result = new List<string>() { "Volume Tool", "Hitsound Editor"};
                    break;

                case 3:
                    result = new List<string>() { "Song Setup", "Bpm Detector Tool", "Note Shifter/Snapper","Tips"};
                    break;

                case 4:
                    result = new List<string>() { "Slider Art Generator"};
                    break;

                default:
                    result = new List<string>() { "Error"};
                    break;
            }
            return result;
        } 
        */
    }
}