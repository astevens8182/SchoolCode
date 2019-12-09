using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryItOut
{
    public partial class Form1 : Form
    {
        decimal finalPay = 0;
        decimal convertedPayRate = 0;
        decimal convertedHoursWorked = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
                   
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtName) & Validator.IsPresent(txtHoursWorked) & Validator.IsPresent(txtPayRate) )
            {
                if (Validator.IsDecimal(txtHoursWorked) & Validator.IsDecimal(txtPayRate) )
                {
                    if (Validator.IsWithinRange(txtHoursWorked, 0, 60) & Validator.IsWithinRange(txtPayRate, 0, 999))
                    {

                        convertedHoursWorked = Convert.ToDecimal(txtHoursWorked.Text);
                        convertedPayRate = Convert.ToDecimal(txtPayRate.Text);

                        finalPay = convertedPayRate * convertedHoursWorked;

                        MessageBox.Show(txtName.Text + " final pay: " + finalPay);
                    }


                }


            }


            
        }
    }
}
