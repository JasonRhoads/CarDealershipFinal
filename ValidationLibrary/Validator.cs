using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ValidationLibrary
{
    /// <summary>
    /// Provides static methods for validating data.
    /// </summary>
    public static class Validator
    {
      
        //Check to see if a value was entered
        public static string IsPresent(System.Windows.Forms.TextBox textbox, string name)
        {
            string msg = "";
            if (textbox.Text == "")
            {
                msg += $"\n{name} is a required field";
            }

            return msg;
        }

        public static string IsInt(TextBox textbox, string name)
        {
            string msg = "";
            if (!int.TryParse(textbox.Text, out _))
            {
                msg += $"\n{name} needs to be a number ex, 0 - 20";
            }

            return msg;
        }

        public static string IsDecimal(TextBox textbox, string name)
        {
            string msg = "";
            if (!decimal.TryParse(textbox.Text, out _))
            {
                msg += $"\n{name} needs to be a number ex, 100 - 2000000";
            }

            return msg;
        }

    }
}
