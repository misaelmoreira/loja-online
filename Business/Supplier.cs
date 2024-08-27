﻿using System.Collections.Generic;

namespace Business
{
    public class Supplier

    {
        public Supplier()
        {
            this.Produtos = new HashSet<Produto>();
        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
