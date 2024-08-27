using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            
        }

        public int CustomerID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public List<Customer> Lista()
        {

            var lista = new List<Customer>();
            var clienteDb = new Database.Customer();

            foreach (DataRow row in clienteDb.Lista().Rows)
            {
                var cliente = new Customer();
                cliente.CustomerID = Convert.ToInt32(row["CustomerID"]);
                cliente.First_Name = row["[First Name]"].ToString();
                cliente.Last_Name = row["[Last Name]"].ToString();
                cliente.UserName = row["Username"].ToString();
                cliente.Password = row["Password"].ToString();
                cliente.Age = Convert.ToInt32(row["Age"]);
                cliente.Gender = row["Gender"].ToString();
                cliente.Email = row["Email"].ToString();

                lista.Add(cliente);
            }
            return lista;
        }

        public static Customer BuscaPorId(int id)
        {
            var cliente = new Customer();
            var clienteDb = new Database.Customer();
            foreach (DataRow row in clienteDb.BuscaPorId(id).Rows)
            {
                cliente.CustomerID = Convert.ToInt32(row["CustomerID"]);
                cliente.First_Name = row["First Name"].ToString();
                cliente.Last_Name = row["Last Name"].ToString();
                cliente.UserName = row["UserName"].ToString();
                cliente.Password = row["Password"].ToString();
                cliente.Age = Convert.ToInt32(row["Age"]);
                cliente.Gender = row["Gender"].ToString();
                cliente.Email = row["Email"].ToString();

            }
            return cliente;
        }

        public static Customer BuscaPorUsername(string UserName)
        {
            var cliente = new Customer();
            var clienteDb = new Database.Customer();
            foreach (DataRow row in clienteDb.BuscaPorUsername(UserName).Rows)
            {
                cliente.CustomerID = Convert.ToInt32(row["CustomerID"]);
            }
            return cliente;
        }

        public void Save()
        {
            new Database.Customer().Salvar(
                this.First_Name,
                this.Last_Name,
                this.UserName,
                this.Password,
                this.Age,
                this.Gender,
                this.Email
                ) ;
        }

        public void Atualizar()
        {
            new Database.Customer().Atualizar(
                this.CustomerID,
                this.First_Name,
                this.Last_Name,
                this.UserName,
                this.Password,
                this.Age,
                this.Gender,
                this.Email
                );
        }

        public static Customer ValidaUser(string Email)
        {
            var cliente = new Customer();
            var clienteDb = new Database.Customer();
            foreach (DataRow row in clienteDb.ValidaUser(Email).Rows)
            {
                cliente.CustomerID = Convert.ToInt32(row["CustomerID"]);
                cliente.UserName = row["UserName"].ToString();
                cliente.Email = row["Email"].ToString();
                cliente.Password = row["Password"].ToString();               

            }
            return cliente;
        }
    }
}
