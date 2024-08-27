using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Order
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Orders";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public int Total()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select count(*) from Orders";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                int count = Convert.ToInt32(table.Rows[0][0]);
                return count;
            }
        }

        public void Salvar(int OrderID, int CustomerID, int? PaymentID, int? ShippingID, int? Discount, int? Taxes, int? TotalAmount, bool? isCompleted, DateTime? OrderDate, bool? Dispatched, DateTime? DispatchedDate, bool? Shipped, DateTime? ShippingDate, bool? Deliver, DateTime? DeliveryDate, string Notes, bool? CancelOrder)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into Orders(OrderID, CustomerID, PaymentID, ShippingID, Discount, Taxes, TotalAmount, isCompleted, OrderDate, Dispatched, DispatchedDate, Shipped, ShippingDate, Deliver, DeliveryDate, Notes, CancelOrder ) values('" + OrderID + "','" + CustomerID + "','" + PaymentID + "','" + ShippingID + "','" + Discount + "','" + Taxes + "','" + TotalAmount + "','" + isCompleted + "','" + OrderDate + "','" + Dispatched + "','" + DispatchedDate + "','" + Shipped + "','" + ShippingDate + "','" + Deliver + "','" + DeliveryDate + "','" + Notes + "','" + CancelOrder + "')";
                
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(int OrderID, int CustomerID, int? PaymentID, int? ShippingID, int? Discount, int? Taxes, int? TotalAmount, bool? isCompleted, DateTime? OrderDate, bool? Dispatched, DateTime? DispatchedDate, bool? Shipped, DateTime? ShippingDate, bool? Deliver, DateTime? DeliveryDate, string Notes, bool? CancelOrder)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update Orders set CustomerID='" + CustomerID + "', PaymentID='" + PaymentID + "', ShippingID='" + ShippingID + "', Discount='" + Discount + "', Taxes='" + Taxes + "',TotalAmount='" + TotalAmount + "', isCompleted='" + isCompleted + "', OrderDate='" + OrderDate + "', Dispatched = '" + Dispatched + "' , DispatchedDate = '" + DispatchedDate + "', Shipped = '" + Shipped + "', ShippingDate = '" + ShippingDate + "', Deliver = '" + Deliver + "', DeliveryDate = '" + DeliveryDate + "', Notes = '" + Notes + "', CancelOrder = '" + CancelOrder + "' where OrderID=" + OrderID;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Orders where OrderID=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
