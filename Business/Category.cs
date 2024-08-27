using System;
using System.Collections.Generic;

namespace Business
{
    public class Category
    {
        public Category()
        {            
            this.Produto = new HashSet<Produto>();
        }

        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public Nullable<bool> isActive { get; set; }


        public virtual ICollection<Produto> Produto { get; set; }      

    }
}
