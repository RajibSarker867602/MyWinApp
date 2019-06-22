using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class DepartmentUi : Form
    {
        class Department
        {
            public int ID { set; get; }
            public string Name { set; get; }
            public string Code { set; get; }
        }

        public DepartmentUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Insert();
            //string name = "Computer Science & Engineering";
            //string code = "CSE";
            //Insert(name, code);

            //
            //string name = nameTextBox.Text;
            //string code = codeTextBox.Text;
            //Insert(name, code);
            //
            Department department = new Department();

            department.Name = nameTextBox.Text;
            department.Code = codeTextBox.Text;

            Insert(department);


        }

        //private void Insert(string name, string code)
        private void Insert(Department department)

        {
            try
            {
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=BITM-TRAINER-30\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
                sqlConnection.ConnectionString = connectionString;

                //2
                SqlCommand sqlCommand = new SqlCommand();
                //string commandString = @"INSERT INTO Departments (Name, Code) Values ('Computer Science & Engineering','CSE')";
                string commandString = @"INSERT INTO Departments (Name, Code) Values ('"+ department.Name+ "','"+ department.Code + "')";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                int isExecuted = 0;

                isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved Successfully!");
                }
                else
                {
                    MessageBox.Show("Save Failed");
                }

                //5
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            //
            string connectionString = @"Server=BITM-TRAINER-30\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Departments";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                displayDataGridView.DataSource = dataTable;
            }



            sqlConnection.Close();


        }
    }
}
