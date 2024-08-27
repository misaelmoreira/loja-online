using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class ShippingDetail
    {
        public ShippingDetail()
        {
            this.Orders = new HashSet<Order>();
        }
        public int ShippingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


        public List<ShippingDetail> Lista()
        {

            var lista = new List<ShippingDetail>();
            var itemCompraDb = new Database.ShippingDetail();

            foreach (DataRow row in itemCompraDb.Lista().Rows)
            {
                var pcompra = new ShippingDetail();
                pcompra.ShippingID = Convert.ToInt32(row["ShippingID"]);
                pcompra.FirstName = row["FirstName"].ToString();
                pcompra.LastName = row["LastName"].ToString();
                pcompra.Email = row["Email"].ToString();
                pcompra.Mobile = row["Mobile"].ToString();
                pcompra.Address = row["Address"].ToString();
                pcompra.Province = row["Province"].ToString();
                pcompra.City = row["City"].ToString();
                pcompra.PostCode = row["PostCode"].ToString();
                

                lista.Add(pcompra);
            }
            return lista;
        }

        public int Count()
        {
            var itemCompraDb = new Database.ShippingDetail();            
            return itemCompraDb.Total();
        }

        public void Save()
        {
            new Database.ShippingDetail().Salvar(
                this.ShippingID,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Mobile,
                this.Address,
                this.Province,                
                this.City,
                this.PostCode
                );
        }

        public void Atualizar()
        {
            new Database.ShippingDetail().Salvar(
                this.ShippingID,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Mobile,
                this.Address,
                this.Province,
                this.City,
                this.PostCode
                );
        }
    }
}
