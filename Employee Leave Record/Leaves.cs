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

namespace Employee_Leave_Record
{
    public partial class Leaves : Form
    {
        Functions Con;
        public Leaves()
        {
            InitializeComponent();
            Con = new Functions();
            ShowLeaves();
            GetEmployees();
            GetCategories();
        }
        private void ShowLeaves()
        {
            string Query = "select * from LeaveTbl ";
            LeavesList.DataSource = Con.GetData(Query);

        }
        private void FilterLeaves()
        {
            string Query = "select * from LeaveTbl Where Status = '{0}' ";
            Query = string.Format(Query,SearchCb.SelectedIndex.ToString());
            LeavesList.DataSource = Con.GetData(Query);

        }
        private void GetEmployees()
        {
            string Query = "select * from EmployeeTbl ";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }
        private void GetCategories()
        {
            string Query = "select * from CategoryTbl ";
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.ValueMember = Con.GetData(Query).Columns["CatId"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1 )
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    int Emp = Convert.ToInt32(EmpCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                    string DateEnd = DateEndTb.Value.Date.ToString();
                    string DateApplied = DateTime.Today.Date.ToString();
                    //string Status = StatusCb.SelectedItem.ToString();
                    string Status = " Pending ";
                    string Query = " insert into LeaveTbl values({0},'{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Emp, Category, DateStart, DateEnd, DateApplied, Status);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Added!!!");

                   /* EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";*/


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }


        private void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    int Emp = Convert.ToInt32(EmpCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                    string DateEnd = DateEndTb.Value.Date.ToString();
                    string DateApplied = DateTime.Today.Date.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                   
                    string Query = "Update LeaveTbl set Employee = {0},Category = {1},DateStart = '{2}',DateEnd = '{3}',Status = '{4}' Where LId = {5}";
                    Query = string.Format(Query, Emp, Category, DateStart, DateEnd, Status, key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Updated!!!");


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        int key = 0;
        private void LeavesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            EmpCb.Text = LeavesList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = LeavesList.SelectedRows[0].Cells[2].Value.ToString();
            DateStartTb.Text = LeavesList.SelectedRows[0].Cells[3].Value.ToString();
            DateEndTb.Text = LeavesList.SelectedRows[0].Cells[4].Value.ToString();
            StatusCb.Text = LeavesList.SelectedRows[0].Cells[6].Value.ToString();


            if (EmpCb.SelectedIndex == -1)
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(LeavesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    
                    string Query = " Delete from  LeaveTbl   Where LId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Deleted!!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ShowLeaves();
        }

        private void SearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLeaves();
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void catLbl_Click(object sender, EventArgs e)
        {
            Categories obj = new Categories();
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
    }
}
