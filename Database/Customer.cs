using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Customer
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Customers";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(string First_Name, string Last_name, string UserName, string Password, int Age, string Gender, string Email )
            
         {
             using (SqlConnection connection = new SqlConnection(sqlConn()))
             {
                 string queryString = "insert into Customers([First Name], [Last Name], UserName, Password, Age, Gender, Email ) values('" + First_Name + "','" + Last_name + "','" + UserName + "','" + Password + "','" + Age + "','" + Gender + "','" + Email + "')";
                 SqlCommand command = new SqlCommand(queryString, connection);
                 command.Connection.Open();
                 command.ExecuteNonQuery();
             }
         }

        public void Atualizar(int CustomerID, string First_Name, string Last_name, string UserName, string Password, int Age, string Gender, string Email)

        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update Customers set [First Name]='" + First_Name + "' , [Last Name]='" + Last_name + "', UserName='" + UserName + "', Password='" + Password + "', Age='" + Age + "', Gender='" + Gender + "' , Email='" + Email + "' where CustomerID=" + CustomerID;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = " delete from Customers where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Customers where CustomerID=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable BuscaPorUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Customers where UserName = @username";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@username", username);               

                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable ValidaUser(string Email)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Customers where Email='"+ Email + "'";

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
