using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class Product
    {
        private string productid;
        private string productname;
        private float price;
        private float costprice;
        private int stock;
        private string status;
        private string description;
        public Product() { }
        public Product(string productid, string productname, float price, float costprice, int stock, string status, string description)
        {
            this.productid = productid;
            this.productname = productname;
            this.price = price;
            this.costprice = costprice;
            this.stock = stock;
            this.status = status;
            this.description = description;
        }
        public string ProductID { get { return productid; } set { productid = value; } }
        public string ProductName { get { return productname; } set {productname = value; } }
        public float Price { get { return price; } set { price = value; } }
        public float CostPrice { get { return costprice; } set { costprice = value; } }
        public int Stock { get { return stock; } set { stock = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
