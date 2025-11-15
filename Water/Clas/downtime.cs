using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class downtime
    {
        public void ADD_DOWNTIME(string id, string period_id, DateTime date, double hours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[1].Value = period_id;

            param[2] = new SqlParameter("@date", SqlDbType.Date);
            param[2].Value = date;

            param[3] = new SqlParameter("@hours", SqlDbType.Float);
            param[3].Value = hours;

            DAL.ExecuteCommand("downtime_insert", param);
            DAL.Close();
        }
    }
}

