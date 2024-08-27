using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class ShippingDetail
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from ShippingDetails";
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
                string queryString = "select count(*) from ShippingDetails";
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

        public void Salvar(int ShippingID, string FirstName, string LastName, string Email, string Mobile, string Address, string Province, string City, string PostCode)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into ShippingDetails(ShippingID, FirstName, LastName, Email, Mobile, Address, Province, City, PostCode ) values('" + ShippingID + "','" + FirstName + "','" + LastName + "','" + Email + "','" + Mobile + "','" + Address + "','" + Province + "','" + City + "','" + PostCode + "')";
                
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(int ShippingID, string FirstName, string LastName, string Email, string Mobile, string Address, string Province, string City, string PostCode)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update ShippingDetails set FirstName='" + FirstName + "' , LastName='" + LastName + "', Email='" + Email + "', Mobile='" + Mobile + "', Address='" + Address + "', Province='" + Province + "', City='" + City + "', PostCode='" + PostCode + "' where ShippingID=" + ShippingID;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = " delete from ShippingDetails where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from ShippingDetails where id=" + id;
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
