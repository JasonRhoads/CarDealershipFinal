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
      
        /// <summary>
        /// Check to see if a value was entered
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="name"></param>
        /// <returns>if successful, returns an empty string "", if fails returns a message</returns>
        public static string IsPresent(System.Windows.Forms.TextBox textbox, string name)
        {
            string msg = "";
            if (textbox.Text == "")
            {
                msg += $"\n{name} is a required field";
            }

            return msg;
        }


        /// <summary>
        /// Check to see in an Int was entered
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="name"></param>
        /// <returns>if successful, returns an empty string "", if fails returns a message</returns>
        public static string IsInt(TextBox textbox, string name)
        {
            string msg = "";
            if (!int.TryParse(textbox.Text, out _))
            {
                msg += $"\n{name} needs to be a number ex, 0 - 20";
            }

            return msg;
        }


        /// <summary>
        /// Check to see if a valid Decimal was entered
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="name"></param>
        /// <returns>if successful, returns an empty string "", if fails returns a message</returns>
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
