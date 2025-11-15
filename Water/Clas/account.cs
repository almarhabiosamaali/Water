using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class account
    {
        public void ADD_ACCOUNT(string id, string name, string notes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 255);
            param[1].Value = name;

            param[2] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[2].Value = notes;

            DAL.ExecuteCommand("account_insert", param);
            DAL.Close();
        }
    }
}

