using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Leave_Record
{
    
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        public static int EmpId;
        public static String EmpName = "";

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else {
                if (UNameTb.Text == "arslan" && PasswordTb.Text == "123" || UNameTb.Text == "taha" && PasswordTb.Text == "123" || UNameTb.Text == "fahad" && PasswordTb.Text == "123")
                {
                    Employees obj = new Employees();
                    obj.Show();
                    this.Hide();

                }
                else
                { try
                    {
                        string Query = "select * from EmployeeTbl Where EmpName = '{0}' and EmpPass = '{1}'";
                        Query = string.Format(Query, UNameTb.Text, PasswordTb.Text);
                        DataTable dt = Con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show(" Incorrect Password!!!");
                            UNameTb.Text = "";
                            PasswordTb.Text = "";
                        }
                        else
                        {
                            EmpId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            EmpName = dt.Rows[0][1].ToString();
                            ViewLeave obj = new ViewLeave();
                            obj.Show();
                            this.Hide();


                        }
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    
                }
                    
               }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PasswordTb.Text = "";


        }
    }
}
