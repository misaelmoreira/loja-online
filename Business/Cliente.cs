using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public List<Cliente> Lista()
        {

            var lista = new List<Cliente>();
            var clienteDb = new Database.Cliente();
            
            foreach(DataRow row in clienteDb.Lista().Rows)
            {
                var cliente = new Cliente();
                cliente.Id = Convert.ToInt32(row["id"]);
                cliente.Nome = row["nome"].ToString();
                cliente.Telefone = row["telefone"].ToString();
                cliente.Email = row["email"].ToString();

                lista.Add(cliente);
            }
            return lista;            
        }
    }
}
