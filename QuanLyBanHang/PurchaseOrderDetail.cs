using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class PurchaseOrderDetail
    {
        private int orderdetailID;
        private int purchaseorderID;
        private string productid;
        private int quantity;
        private float unitcost;
        private float totalcost;
        private float sellingprice;
        public PurchaseOrderDetail() { }
        public PurchaseOrderDetail(int orderdetailID, int purchaseorderID, string productid, int quantity, float unitcost, float totalcost, float sellingprice)
        {
            this.orderdetailID = orderdetailID;
            this.purchaseorderID = purchaseorderID;
            this.productid = productid;
            this.quantity = quantity;
            this.unitcost = unitcost;
            this.totalcost = totalcost;
            this.sellingprice = sellingprice;
        }
        public int OrderdetailID { get { return orderdetailID; } set { orderdetailID = value; } }
        public int Purchase { get { return purchaseorderID; } set { purchaseorderID = value; } }
        public string Productid { get { return productid; } set { productid = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public float Unitcost { get { return unitcost; } set { unitcost = value; } }
        public float Totalcost { get {return totalcost; } set { totalcost = value; } }
        public float SellingPrice { get { return sellingprice; } set { sellingprice = value; } }

    }
}
