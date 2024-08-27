using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class OrderDetail
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }


        public void Salvar(int OrderDetailsId, int OrderID, int ProductID, decimal? UnitPrice, int? Quantity, decimal? TotalAmount, decimal? Discount, DateTime? OrderDate )


        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {

                string queryString = "insert into OrderDetails(OrderID, ProductID ) values('" + OrderID + "','" + ProductID + "')";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        
    }
}
