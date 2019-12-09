using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// This class has all  data vaildations that might be used throughout the program.
/// </summary>
namespace Homework1
{
    public static class Validator
    {

        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresentStrings(string stringName)
        {
            if (string.IsNullOrEmpty(stringName))
            {


                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsPresentStringsSingleOrMarried(string stringName)
        {
            if (stringName == "M" || stringName =="S")
            {


                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool IsDecimal(string stringName)
        {
            try
            {
                Convert.ToDecimal(stringName);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsWithinRange(string stringName, decimal min, decimal max)
        {


            decimal number = Convert.ToDecimal(stringName);
            if (number < min || number > max)
            {
                ///write error
             
                return false;
            }
            return true;
        }

    }
}



