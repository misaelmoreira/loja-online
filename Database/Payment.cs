using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Payment
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Payment";
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
                string queryString = "select count(*) from Payment";
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

        public void Salvar(int PaymentID, int Type)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into Payment( PaymentID, Type ) values('" + PaymentID + "','" + Type + "')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(int PaymentID, int Type)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update Payment set PaymentID ='" + PaymentID + "' , Type='" + Type + "' where PaymentID=" + PaymentID;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
             using (SqlConnection connection = new SqlConnection(sqlConn()))
             {
                 string queryString = " delete from Payment where id=" + id;

                 SqlCommand command = new SqlCommand(queryString, connection);
                 command.Connection.Open();

                 command.ExecuteNonQuery();
             }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Payment where PaymentID=" + id;
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
