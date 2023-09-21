using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Employee_Leave_Record
{
    public partial class Categories : Form
    {
        Functions Con;

        public Categories()
        {
            
            InitializeComponent();
            Con = new Functions();
            ShowCategories();



        }
        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl ";
            CategoriesList.DataSource = Con.GetData(Query);

        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CapNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Category = CapNameTb.Text;
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Category);
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
           
        }
        int key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                CapNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();


                if (CapNameTb.Text == "")
                {
                    key = 0;

                }
                else
                {
                    key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
                }
           
           
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CapNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Category = CapNameTb.Text;
                    string Query = "Update CategoryTbl set CatName = '{0}' Where CatId = {1} ";
                    //Query = string.Format( Query, Category, key);
                    Query = string.Format(Query, Category,key);
                    Con.SetData( Query );
                    ShowCategories();
                    CapNameTb.Text = "";


                }
            }
             catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Category = CapNameTb.Text;
                    string Query = "delete from CategoryTbl  Where CatId = {0} ";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";

                }




            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void CategoriesList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CapNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();


                if (CapNameTb.Text == "")
                {
                    key = 0;

                }
                else
                {
                    key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void LeavesLbl_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    


}

