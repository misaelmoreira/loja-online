using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class PaymentType
    {
        public PaymentType()
        {
            this.Payments = new HashSet<PaymentType>();
        }

        public int PayTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PaymentType> Payments { get; set; }

        public List<PaymentType> Lista()
        {
            var lista = new List<PaymentType>();
            var TipoPagamentoDb = new Database.PaymentType();

            foreach (DataRow row in TipoPagamentoDb.Lista().Rows)
            {
                var pagamento = new PaymentType();
                pagamento.PayTypeID = Convert.ToInt32(row["PayTypeID"]);
                pagamento.TypeName = Convert.ToString(row["TypeName"]);
                pagamento.Description = Convert.ToString(row["Description"]);

                lista.Add(pagamento);
            }
            return lista;
        }

        public int Count()
        {
            var TipoPagamentoDb = new Database.PaymentType();
            return TipoPagamentoDb.Total();
        }

        public void Save()
        {
            new Database.PaymentType().Salvar(
                this.PayTypeID,
                this.TypeName,
                this.Description
                );
        }

        public void Atualizar()
        {
            new Database.PaymentType().Atualizar(
                this.PayTypeID,
                this.TypeName,
                this.Description
                );
        }
    }
}
