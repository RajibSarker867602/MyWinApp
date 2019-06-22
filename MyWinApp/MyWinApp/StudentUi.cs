using MyWinApp.Models;
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
    public partial class StudentUi : Form
    {
        SqlDataReader reader;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string connectionString = @"Server=DESKTOP-GIQEBOC\SQLSERVER2017; Database=StudentDataBase; User Id=sa; Password=Batch_37";
        Student student;
        public StudentUi()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveButton.Text == "Save")
                {
                    if (IsFormValid())
                    {
                        student = new Student();
                        student.RollNo = rollNoTextBox.Text;
                        if (IsExistRoll(student.RollNo))
                        {
                            MessageBox.Show("Roll no already exist!");
                            return;
                        }
                        student.Name = nameTextBox.Text;
                        student.Age = Convert.ToInt32(ageTextBox.Text);
                        student.DistricId = Convert.ToInt32(districtComboBox.SelectedValue);
                        student.Address = addressTextBox.Text;

                        InsertStudent(student);
                    }

                }
                if (SaveButton.Text == "Update")
                {
                    if (IsFormValid())
                    {
                        Student student = new Student();
                        student.RollNo = rollNoTextBox.Text;
                        if (IsExistRoll(student.RollNo))
                        {
                            student.Name = nameTextBox.Text;
                            student.Age = Convert.ToInt32(ageTextBox.Text);
                            student.Address = addressTextBox.Text;
                            student.DistricId = Convert.ToInt32(districtComboBox.SelectedValue);
                            UpdateStudent(student);
                        }
                        else
                        {
                            MessageBox.Show("RollNo are not exist!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsFormValid()
        {
            if (rollNoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter roll no!");
                rollNoTextBox.Clear();
                rollNoTextBox.Focus();
                return false;
            }
            if (nameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter name!");
                nameTextBox.Clear();
                nameTextBox.Focus();
                return false;
            }
            if (ageTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter age!");
                ageTextBox.Clear();
                ageTextBox.Focus();
                return false;
            }
            if (districtComboBox.SelectedIndex <=0)
            {
                MessageBox.Show("Please select district!");
                districtComboBox.Focus();
                return false;
            }
            if (addressTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter address!");
                addressTextBox.Clear();
                addressTextBox.Focus();
                return false;
            }
            return true;
        }

        private bool IsExistRoll(string rollNo)
        {
            try
            {
                string query = "Select *From Students_Tb Where RollNo='" + rollNo + "'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                var row = sqlCommand.ExecuteScalar();
                if (row != null)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return false;
        }

        private void InsertStudent(Student student)
        {
            try
            {
                string query = "Insert Into Students_Tb(RollNo,Name,Age,Address,DistrictId) Values('" + student.RollNo + "','" + student.Name + "','" + student.Age + "','" + student.Address + "','" + student.DistricId + "')";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Save Successful.");

                    Reset();
                }
                else
                {
                    MessageBox.Show("Save Failed!");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Reset()
        {
            rollNoTextBox.Clear();
            rollNoTextBox.ReadOnly = false;
            nameTextBox.Clear();
            addressTextBox.Clear();
            ageTextBox.Clear();
            districtComboBox.SelectedIndex = 0;
            EditButton.Enabled = true;
            SaveButton.Text = "Save";
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {
            LoadDistrictCombo();
        }

        private void LoadDistrictCombo()
        {
            List<District> districts = GetDistricts();
            District district = new District();
            district.Id = 0;
            district.Name = "--Select--";
            districts.Insert(0, district);
            districtComboBox.DataSource = null;
            districtComboBox.DataSource = districts;
            districtComboBox.DisplayMember = "Name";
            districtComboBox.ValueMember = "Id";
        }

        private List<District> GetDistricts()
        {

            List<District> districts = new List<District>();
            sqlConnection = new SqlConnection(connectionString);
            string query = "Select * From Districts";
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    District district = new District();
                    district.Id = (int)reader["Id"];
                    district.Name = reader["Name"].ToString();
                    districts.Add(district);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return districts;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            List<Student> students = GetStudents();
            BindStudentsGridView(students);
        }

        private void BindStudentsGridView(List<Student> students)
        {
            int serial = 0;
            displayDataGridView.Rows.Clear();
            foreach (var student in students)
            {
                serial++;
                displayDataGridView.Rows.Add(serial, student.Id, student.RollNo, student.Name, student.Age, student.Address, student.DistrictName, student.DistricId);
            }
        }

        private List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string query = "Select * From StudentsView";
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.RollNo = reader["RollNo"].ToString();
                    student.Name = reader["Name"].ToString();
                    student.Age = Convert.ToInt32(reader["Age"]);
                    student.Address = reader["Address"].ToString();
                    student.DistricId = Convert.ToInt32(reader["DistrictId"]);
                    student.DistrictName = reader["DistrictName"].ToString();
                    students.Add(student);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return students;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    Student student = new Student();
                    student.RollNo = rollNoTextBox.Text;
                    if (IsExistRoll(student.RollNo))
                    {
                        student.Name = nameTextBox.Text;
                        student.Age = Convert.ToInt32(ageTextBox.Text);
                        student.Address = addressTextBox.Text;
                        student.DistricId = Convert.ToInt32(districtComboBox.SelectedValue);
                        UpdateStudent(student);
                    }
                    else
                    {
                        MessageBox.Show("RollNo are not exist!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStudent(Student student)
        {
            try
            {
                string query = "Update Students_Tb SET Name='" + student.Name + "', Age='" + student.Age + "',Address='" + student.Address + "',DistrictId='" + student.DistricId + "' Where RollNo='" + student.RollNo + "'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int row = sqlCommand.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Update Successful.");
                    Reset();
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void displayDataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (displayDataGridView.CurrentRow.Index != -1)
                {
                    rollNoTextBox.Text = displayDataGridView.CurrentRow.Cells[2].Value.ToString();
                    nameTextBox.Text = displayDataGridView.CurrentRow.Cells[3].Value.ToString();
                    ageTextBox.Text = displayDataGridView.CurrentRow.Cells[4].Value.ToString();
                    addressTextBox.Text = displayDataGridView.CurrentRow.Cells[5].Value.ToString();
                    districtComboBox.Text = displayDataGridView.CurrentRow.Cells[6].Value.ToString();
                    EditButton.Enabled = false;
                    SaveButton.Text = "Update";
                    rollNoTextBox.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (rollNoTextBox.Text != "")
                {
                    if (MessageBox.Show("Do you want to delete '" + rollNoTextBox.Text + "' this roll no?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (IsExistRoll(rollNoTextBox.Text))
                        {
                            string query = "Delete From Students_Tb Where RollNo='" + rollNoTextBox.Text + "'";
                            sqlConnection = new SqlConnection(connectionString);
                            sqlCommand = new SqlCommand(query, sqlConnection);
                            sqlConnection.Open();
                            int row = sqlCommand.ExecuteNonQuery();
                            if (row > 0)
                            {
                                MessageBox.Show("Delete Successful.");
                                Reset();
                            }
                            else
                            {
                                MessageBox.Show("Delete Failed!");
                            }
                            sqlConnection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Roll no are not exist!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter roll no!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (rollNoTextBox.Text != "")
                {
                    if (IsExistRoll(rollNoTextBox.Text))
                    {
                        string rollNo = rollNoTextBox.Text.ToLower();
                        var data = GetStudents().Where(c => c.RollNo.ToLower().Contains(rollNo)).ToList();
                        BindStudentsGridView(data);
                    }
                    else
                    {
                        MessageBox.Show("Student not found!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter roll no!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
