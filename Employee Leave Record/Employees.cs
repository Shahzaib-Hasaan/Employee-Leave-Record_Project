using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Employee_Leave_Record
{
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployees();

        }
        private void ShowEmployees()
        {
            string Query = "select * from EmployeeTbl ";
            EmployeesList.DataSource = Con.GetData(Query);

        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (EmpNameTb.Text == "" ||EmpPhoneTb.Text == "" || PasswordTb.Text == "" ||EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Name  = EmpNameTb.Text;
                    string Gender = EmpGenCb.Text;
                    string Phone = EmpPhoneTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;
                    string Query = "insert into EmployeeTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name, Gender, Phone , Pass, Add);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                    

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        int key = 0;
        private void EmployeesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeesList.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenCb.Text = EmployeesList.SelectedRows[0].Cells[2].Value.ToString();
            EmpPhoneTb.Text = EmployeesList.SelectedRows[0].Cells[3].Value.ToString();
            PasswordTb.Text = EmployeesList.SelectedRows[0].Cells[4].Value.ToString();
            AddTb.Text = EmployeesList.SelectedRows[0].Cells[5].Value.ToString();


            if (EmpNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(EmployeesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenCb.Text;
                    string Phone = EmpPhoneTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;
                    string Query = "update EmployeeTbl set EmpName = '{0}',EmpGen = '{1}', EmpPhone = '{2}', EmpPass = '{3}', EmpAdd = '{4}'  Where EmpId = '{5}' ";
                    Query = string.Format(Query, Name, Gender, Phone, Pass, Add, key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Update!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    
                    string Query = "delete from EmployeeTbl Where EmpId = '{0}' ";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Deleted!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void CategoryLbl_Click(object sender, EventArgs e)
        {
            Categories obj = new Categories();
            obj.Show();
            this.Hide();
        }

        private void LeaveLbl_Click(object sender, EventArgs e)
        {
            Leaves obj = new Leaves();
            obj.Show();
            this.Hide();
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}

