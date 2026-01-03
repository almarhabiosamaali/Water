using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class user
    {
        public DataTable LOGIN_USER(string signInName, string password)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            
            param[0] = new SqlParameter("@SignInName", SqlDbType.VarChar, 50);
            param[0].Value = signInName;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = password;

            DataTable dt = DAL.SelectData("user_login", param);
            DAL.Close();
            return dt;
        }
    }
}

