using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIProject_Visualization.AppCode
{
    public class ComboboxDAL
    {
        DAL db = null;
        public ComboboxDAL()
        {
            db = new DAL();
        }
        public static DataTable GetCity()
        {
            DAL db = new DAL();
            return db.ExecuteQueryDataSet(
                "P_GetCity",
                CommandType.StoredProcedure,
                null).Tables[0];
        }
        public static DataTable GetState()
        {
            DAL db = new DAL();
            return db.ExecuteQueryDataSet(
                "P_GetState",
                CommandType.StoredProcedure,
                null).Tables[0];
        }
    }
}
