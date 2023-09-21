using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Leave_Record
{
    class Functions

    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string Constr;

        public Functions() 
        {
            //Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\apple\Documents\LeaveDb;Integrated Security=True;Connect Timeout=30";
            Constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LeaveDb; Integrated Security = True; Connect Timeout = 30"; 
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
        public DataTable GetData(String Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Con);
            sda.Fill(dt);
            return dt;

        }
        public int SetData(String Query)
        {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed) 
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            return cnt; 
        }

    }
}
