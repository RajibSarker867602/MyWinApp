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
    public partial class CustomerForm : Form
    {
        List<string> users = new List<string>();
        List<string> names = new List<string>();
        List<int> ages = new List<int>();
        
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string user;
                string name;
                int age;
                userLabel.Text = "";

                user = uaseTextBox.Text;

                if (UserExists(user))
                {
                    userLabel.Text = "User "+ user + " already Exists!!";
                    return;
                }

                if (String.IsNullOrEmpty(ageTextBox.Text))
                {
                   
                    MessageBox.Show("Age field can not be empty!!");
                    return;
                }

                if (!Int32.TryParse(ageTextBox.Text, out int result))
                {
                    MessageBox.Show("Age Invalied!!");
                    return;
                }


                name = nameTextBox.Text;
                age = Convert.ToInt32(ageTextBox.Text);

                ages.Add(age);
                users.Add(user);
                names.Add(name);
               
                dsplayRichTextBox.Text = Display();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private string Display()
        {
            string message = "";
            message = "Sl\tUser\tName\tAge\n";

            for (int index = 0; index < users.Count; index++)
            {
                message = message + (index+1) +"\t"+  users[index]+"\t"+names[index]+"\t"+ages[index]+"\n";
            }

            return message;
        }

        private bool UserExists(string user)
        {
            bool isExists = false;

            foreach (string userChk in users)
            {
                if (userChk == user)
                    isExists = true;
            }



            return isExists;
        }
    }
}
