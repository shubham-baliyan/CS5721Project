using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.Singleton
{
    public sealed class Connection
    {
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        private static Connection obj = null;

        private Connection()
        {

        }
        private class Nested
        {
            static Nested()
            {

            }
            internal static readonly Connection instance = new Connection();



        }
        public static Connection Instance { get { return Nested.instance; } }

        public static SqlConnection connect()
        {
            string s = ConfigurationManager.ConnectionStrings["SportsArenaEntities"].ConnectionString;
 
            SqlConnection con = new SqlConnection(s);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
            return con;

        }
        public DataTable Selectall(string query)
        {
            da = new SqlDataAdapter(query, Connection.connect());
            dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
        public bool DML(string query)
        {
            cmd = new SqlCommand(query, Connection.connect());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;

            }
            else
            {
                return false;

            }

        }

    }

}