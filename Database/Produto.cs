using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Produto
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Products";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }       

        public DataTable BuscaPorId(int ProductID)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Products where ProductID=" + ProductID;
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
