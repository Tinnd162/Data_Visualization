using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIProject_Visualization.AppCode
{
    public class ReviewDAL
    {
        DAL db = null;
        public ReviewDAL()
        {
            db = new DAL();
        }
        public static DataTable RevenuePerMonth(int year, string city)
        {
            DAL db = new DAL();
            return db.ExecuteQueryDataSet(
                "P_RevenuePerMonthInYear",
                CommandType.StoredProcedure,
                new SqlParameter("@Year", year),
                new SqlParameter("@City", city)).Tables[0];
        }
        public static DataTable TotalCustomerperMonth(int year, string state)
        {
            DAL db = new DAL();
            return db.ExecuteQueryDataSet(
                "P_TotalCustomerperMonthinYeareachState",
                CommandType.StoredProcedure,
                new SqlParameter("@Year", year),
                new SqlParameter("@State", state)).Tables[0];
        }
    }
}
