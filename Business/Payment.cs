using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Payment
    {
        public Payment()
        {
            this.Orders = new HashSet<Order>();
        }

        public int PaymentID { get; set; }
        public int Type { get; set; }      
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<System.DateTime> PaymentDateTime { get; set; }

        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual PaymentType Paymenttype { get; set; }


        public List<Payment> Lista()
        {

            var lista = new List<Payment>();
            var PagamentoDb = new Database.Payment();

            foreach (DataRow row in PagamentoDb.Lista().Rows)
            {
                var pagamento = new Payment();
                pagamento.PaymentID = Convert.ToInt32(row["PaymentID"]);
                pagamento.Type = Convert.ToInt32(row["Type"]);

                lista.Add(pagamento);
            }
            return lista;
        }


        public int Count()
        {
            var PagamentoDb = new Database.Payment();
            return PagamentoDb.Total();
        }

        public void Save()
        {
            new Database.Payment().Salvar(
                this.PaymentID,
                this.Type
                );
        }

        public void Atualizar()
        {
            new Database.Payment().Atualizar(
                this.PaymentID,
                this.Type
                );
        }

        public static Payment BuscaPorId(int id)
        {
            var payment = new Payment();
            var paymentDb = new Database.Payment();
            foreach (DataRow row in paymentDb.BuscaPorId(id).Rows)
            {
                payment.PaymentID = Convert.ToInt32(row["PaymentID"]);
                payment.Type = Convert.ToInt32(row["Type"]);
                payment.CreditAmount = row["CreditAmount"] != DBNull.Value && decimal.TryParse(row["CreditAmount"].ToString(), out decimal creditAmount) ? creditAmount : 0m;
                payment.DebitAmount = row["DebitAmount"] != DBNull.Value && decimal.TryParse(row["DebitAmount"].ToString(), out decimal debitAmount) ? debitAmount : 0m;
                payment.Balance = row["Balance"] != DBNull.Value && decimal.TryParse(row["Balance"].ToString(), out decimal balance) ? balance : 0m;
            }
            return payment;
        }
    }
}
