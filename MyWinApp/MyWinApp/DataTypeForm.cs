using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class DataTypeForm : Form
    {
        public DataTypeForm()
        {
            InitializeComponent();
        }

        private void dataTypeButton_Click(object sender, EventArgs e)
        {
            int firstNumber;
            firstNumber = 10;

            int secondNumber = firstNumber;
            double thirdNumber = secondNumber;

            int fourthNumber = Convert.ToInt32(thirdNumber);
            string number = fourthNumber.ToString();

            



            MessageBox.Show("firstNumber : "+ firstNumber + "secondNumber : " + secondNumber + "thirdNumber : " +thirdNumber );
        }
    }
}
