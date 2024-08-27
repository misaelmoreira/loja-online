using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Produto
    {
        public Produto()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductID { get; set; }
        public string Name { get; set; }      
        public Nullable<decimal> UnitPrice { get; set; }
        public string ImageURL { get; set; }
        public Nullable<bool> AddBadge { get; set; }
        public string OfferTitle { get; set; }
        public string OfferBadgeClass { get; set; }

        public List<Produto> Lista()
        {
            var lista = new List<Produto>();
            var produtoDb = new Database.Produto();
            
            foreach(DataRow row in produtoDb.Lista().Rows)
            {
                var produto = new Produto();
                produto.ProductID = Convert.ToInt32(row["ProductID"]);
                produto.Name = row["Name"].ToString();
                produto.UnitPrice = Convert.ToDecimal(row["UnitPrice"]);
                produto.ImageURL = row["ImageURL"].ToString();
                /*produto.AddBadge = Convert.ToBoolean(row["add_sacola"]);*/
                produto.OfferTitle = row["OfferTitle"].ToString();
                produto.OfferBadgeClass = row["OfferBadgeClass"].ToString();

                lista.Add(produto);
            }
            return lista;            
        }



        public static Produto BuscaPorId(int id)
        {
            var produto = new Produto();
            var produtoDb = new Database.Produto();
            foreach (DataRow row in produtoDb.BuscaPorId(id).Rows)
            {
                produto.ProductID = Convert.ToInt32(row["ProductID"]);
                produto.Name = row["Name"].ToString();
                produto.UnitPrice = Convert.ToDecimal(row["UnitPrice"]);
                produto.ImageURL = row["ImageURL"].ToString();
                /*produto.AddBadge = Convert.ToBoolean(row["add_sacola"]);*/
                produto.OfferTitle = row["OfferTitle"].ToString();
                produto.OfferBadgeClass = row["OfferBadgeClass"].ToString();

            }
            return produto;
        }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
