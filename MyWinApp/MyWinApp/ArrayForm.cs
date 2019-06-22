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
    public partial class ArrayForm : Form
    {
        const int size = 10;
        int[] number = new int[size];
        int index = 0;
        public ArrayForm()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {

            //const int size = 10;
            //int [] firstNumber = new int[size];

            //firstNumber[5] = 10;
            //firstNumber[7] = 3;
            //firstNumber[6] = 5;

            number[5] = 5;
            number[6] = 6;
            number[7] = 7;
            Show();


            //double[] price = new[] {10.2, 10, 6.50};

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            number[index] = Convert.ToInt32(numberTextBox.Text);
            index++;

            showRichTextBox.Text = Show("Add");
        }

        
        private void ReverseButton_Click(object sender, EventArgs e)
        {
            string message = "";
            message =  "Input Value\n";
            message = message + Show("Reverse");

            message = message + "Reverse Value\n";
            for (int index = size-1; index >= 0; index--)
            {
                if (number[index] != 0)
                    message = message + " Element at index[" + index + "] is " + number[index].ToString() + "\n";
            }

            showRichTextBox.Text = message;
        }

        private string Show(string name)
        {
            string message = "";

            for (int index = 0; index < number.Length; index++)
            {
                if (number[index] != 0)
                    message = message + " Element at index[" + index + "] is " + number[index].ToString() + "\n";
            }

            return name + ":\n"+message;
        }

    }
}
