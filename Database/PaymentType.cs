using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class PaymentType
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from PaymentType";
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
                string queryString = "select count(*) from PaymentType";
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

        public void Salvar(int PayTypeID, string TypeName, string Description)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into PaymentType( PayTypeID, TypeName, Description ) values('" + PayTypeID + "','" + TypeName + "','" + Description + "')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(int PayTypeID, string TypeName, string Description)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update PaymentType set PayTypeID ='" + PayTypeID + "', TypeName='" + TypeName + ", Description='" + Description + "' where PayTypeID=" + PayTypeID;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
             using (SqlConnection connection = new SqlConnection(sqlConn()))
             {
                 string queryString = " delete from PaymentType where id=" + id;

                 SqlCommand command = new SqlCommand(queryString, connection);
                 command.Connection.Open();

                 command.ExecuteNonQuery();
             }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from PaymentType where OrderID=" + id;
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
