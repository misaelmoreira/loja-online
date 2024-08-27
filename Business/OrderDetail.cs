using System;

namespace Business
{
    public class OrderDetail
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }      
        public int ProductID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }        
        public Nullable<decimal> Discount { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Order Order { get; set; }


        public void Save()
        {
            new Database.OrderDetail().Salvar(
                this.OrderDetailsID,
                this.OrderID,
                this.ProductID,
                this.UnitPrice,
                this.Quantity,
                this.TotalAmount,
                this.Discount,
                this.OrderDate
                );
        }        
    }
}
