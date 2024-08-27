using System;
using System.Collections.Generic;

namespace Business
{
    public class admin_Employee
    {
        public admin_Employee()
        {
            this.admin_Login = new HashSet<admin_Login>();
        }

        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<admin_Login> admin_Login { get; set; }
    }
}
