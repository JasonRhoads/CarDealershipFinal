using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CarDealershipFinal
{
    public partial class frmUpload : Form
    {
        public frmUpload()
        {
            InitializeComponent();
        }

        //Check to see that all values were entered or selected.
        private bool IsValidData()
        {
            bool isValid = false;
            string msg = IsPresent(txtModel, txtModel.Tag.ToString());
            msg += IsPresent(txtAge, txtAge.Tag.ToString());
            msg += IsInt(txtAge, txtAge.Tag.ToString());
            msg += IsPresent(txtColor, txtColor.Tag.ToString());
            msg += IsPresent(txtPrice, txtPrice.Tag.ToString());
            msg += IsDecimal(txtPrice, txtPrice.Tag.ToString());
            msg += IsPresent(txtVaring, lblVaring.Text);
            

            if (msg == "")
            {
                isValid = true;
            }
            else
            {
                MessageBox.Show(msg, "Entry Error");
            }
            return isValid;
        }


        //Check to see if a value was entered
        private string IsPresent(System.Windows.Forms.TextBox textbox, string name)
        {
            string msg = "";
            if (textbox.Text == "")
            {
                msg += $"\n{name} is a required field";
            }

            return msg;
        }

        private string IsInt(TextBox textbox, string name)
        {
            string msg = "";
            if (!int.TryParse(textbox.Text, out _))
            {
                msg += $"\n{name} needs to be a number ex, 0 - 20";
            }

            return msg;
        }

        private string IsDecimal(TextBox textbox, string name)
        {
            string msg = "";
            if (!decimal.TryParse(textbox.Text, out _))
            {
                msg += $"\n{name} needs to be a number ex, 100 - 2000000";
            }

            return msg;
        }




        //Add a new car to the full listing
        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (IsValidData())
            {
                var selectedMake = cboMake.SelectedItem.ToString().Trim();
                if (selectedMake == nameof(BMW))
                {
                    BMW newCar = new BMW(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Toyota))
                {
                    Toyota newCar = new Toyota(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Ford))
                {
                    Ford newCar = new Ford(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Honda))
                {
                    Honda newCar = new Honda(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboMake.SelectedIndex)
            {
                case 0 : 
                    lblVaring.Text = "Engine:";
                    break;
                case 1:
                    lblVaring.Text = "Height:";
                    break;
                case 2:
                    lblVaring.Text = "Trim:";
                    break;
                case 3:
                    lblVaring.Text = "Mileage:";
                    break;
            }
        }

        private void frmUpload_Load(object sender, EventArgs e)
        {
            cboMake.Items.Clear();
            cboMake.Items.AddRange(CarMakesDB.Get().ToArray());
            cboMake.SelectedIndex = 0;
        }
    }
}
