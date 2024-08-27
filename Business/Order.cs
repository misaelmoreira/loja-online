using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<int> ShippingID { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Taxes { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<bool> Dispatched { get; set; }
        public Nullable<System.DateTime> DispatchedDate { get; set; }
        public Nullable<bool> Shipped { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<bool> Deliver { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> CancelOrder { get; set; }      


        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


        public List<Order> Lista()
        {

            var lista = new List<Order>();
            var pedidoDb = new Database.Order();

            foreach (DataRow row in pedidoDb.Lista().Rows)
            {
                var pedido = new Order();
                pedido.OrderID = Convert.ToInt32(row["OrderID"]);
                pedido.CustomerID = Convert.ToInt32(row["CustomerID"]);
                pedido.PaymentID = Convert.ToInt32(row["PaymentID"]);
                pedido.ShippingID = Convert.ToInt32(row["ShippingID"]);
                pedido.Discount = Convert.ToInt32(row["Discount"]);
                pedido.Taxes = Convert.ToInt32(row["Taxes"]);
                pedido.TotalAmount = Convert.ToInt32(row["TotalAmount"]);
                pedido.isCompleted = Convert.ToBoolean(row["isCompleted"]);
                pedido.OrderDate = Convert.ToDateTime(row["OrderDate"]);
                pedido.Dispatched = Convert.ToBoolean(row["Dispatched"]);
                pedido.DispatchedDate = (row["DispatchedDate"] != DBNull.Value) ? Convert.ToDateTime(row["DispatchedDate"]) : pedido.DispatchedDate;
                pedido.Shipped = Convert.ToBoolean(row["Shipped"]);
                pedido.ShippingDate = (row["ShippingDate"] != DBNull.Value) ? Convert.ToDateTime(row["ShippingDate"]) : pedido.ShippingDate;
                pedido.Deliver = Convert.ToBoolean(row["Deliver"]);
                pedido.DeliveryDate = (row["DeliveryDate"] != DBNull.Value) ? Convert.ToDateTime(row["DeliveryDate"]) : pedido.DeliveryDate;
                pedido.Notes = (row["Notes"] != DBNull.Value) ? Convert.ToString(row["Notes"]) : pedido.Notes;
                pedido.CancelOrder = (row["CancelOrder"] != DBNull.Value) ? Convert.ToBoolean(row["CancelOrder"]) : pedido.CancelOrder;

                pedido.Customer = Customer.BuscaPorId(pedido.CustomerID);
                pedido.Payment = Payment.BuscaPorId((int)pedido.PaymentID);


                lista.Add(pedido);
            }
            return lista;
        }

        public int Count()
        {
            var orderDb = new Database.Order();
            return orderDb.Total();
        }
        public void Save()
        {
            new Database.Order().Salvar(
                this.OrderID,
                this.CustomerID,
                this.PaymentID,
                this.ShippingID,
                this.Discount,
                this.Taxes,
                this.TotalAmount,
                this.isCompleted,
                this.OrderDate,
                this.Dispatched,
                this.DispatchedDate,
                this.Shipped,
                this.ShippingDate,
                this.Deliver,
                this.DeliveryDate,
                this.Notes,
                this.CancelOrder
                );
        }

        public void Atualizar()
        {
            new Database.Order().Atualizar(
                this.OrderID,
                this.CustomerID,
                this.PaymentID,
                this.ShippingID,
                this.Discount,
                this.Taxes,
                this.TotalAmount,
                this.isCompleted,
                this.OrderDate,
                this.Dispatched,
                this.DispatchedDate,
                this.Shipped,
                this.ShippingDate,
                this.Deliver,
                this.DeliveryDate,
                this.Notes,
                this.CancelOrder
                );
        }

        public static Order BuscaPorId(int id)
        {
            var pedido = new Order();
            var pedidoDb = new Database.Order();
            foreach (DataRow row in pedidoDb.BuscaPorId(id).Rows)
            {
                pedido.OrderID = Convert.ToInt32(row["OrderID"]);
                pedido.CustomerID = Convert.ToInt32(row["CustomerID"]);
                pedido.PaymentID = Convert.ToInt32(row["PaymentID"]);
                pedido.ShippingID = Convert.ToInt32(row["ShippingID"]);
                pedido.Discount = Convert.ToInt32(row["Discount"]);
                pedido.Taxes = Convert.ToInt32(row["Taxes"]);
                pedido.TotalAmount = Convert.ToInt32(row["TotalAmount"]);
                pedido.isCompleted = Convert.ToBoolean(row["isCompleted"]);
                pedido.OrderDate = Convert.ToDateTime(row["OrderDate"]);
                pedido.Dispatched = Convert.ToBoolean(row["Dispatched"]);
                pedido.DispatchedDate = Convert.ToDateTime(row["DispatchedDate"]);
                pedido.Shipped = Convert.ToBoolean(row["Shipped"]);
                pedido.ShippingDate = Convert.ToDateTime(row["ShippingDate"]);
                pedido.Deliver = Convert.ToBoolean(row["Deliver"]);
                pedido.DeliveryDate = Convert.ToDateTime(row["DeliveryDate"]);
                pedido.Notes = Convert.ToString(row["Notes"]);
                pedido.CancelOrder = Convert.ToBoolean(row["CancelOrder"]);

                pedido.Customer = Customer.BuscaPorId(pedido.CustomerID);
                pedido.Payment = Payment.BuscaPorId((int)pedido.PaymentID);

            }
            return pedido;
        }
    }
}
