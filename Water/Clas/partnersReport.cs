using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class partnersReport
    {

        public DataTable PRINT_PARTNER_MOVEMENT(string partner_no)
        {

            Clas.DataAccessLayer DBL = new Clas.DataAccessLayer();
            DBL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@partner_no", SqlDbType.VarChar,50);
            param[0].Value = partner_no;



            DataTable dt = new DataTable();
            dt = DBL.SelectData("proc_partner_movements", param);



            DBL.Close();
            return dt;
        }
    }
}
