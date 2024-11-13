using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class Supplier
    {
        private string supplierid;
        private string suppliername;
        private string email;
        private string phone;
        private string status;
        private List<Supplier> suppliers = new List<Supplier>();
        public Supplier() { }
        public Supplier(string supplierid, string suppliername, string email, string phone, string status)
        {
            this.supplierid = supplierid;
            this.suppliername = suppliername;
            this.email = email;
            this.phone = phone;
            this.status = status;
        }
        public string SupplierID { get { return this.supplierid; } set { this.supplierid = value; } }
        public string SupplierName { get { return this.suppliername; } set {this.suppliername = value; } }
        public string Email { get { return this.email; } set {this.email = value; } }
        public string Phone { get { return this.phone; } set {this.phone = value; } }
        public string Status { get { return this.status; } set {this.status = value; } }
        public List<Supplier> Suppliers { get { return this.suppliers; } set { this.suppliers = value; } } 
    }
}
