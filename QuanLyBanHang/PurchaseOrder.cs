using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class PurchaseOrder
    {
        private int purchaseOrderID;
        private int userID;
        private string orderDate;
        private string supplierID;
        private float totalAmount;
        public PurchaseOrder() { }
        public PurchaseOrder(int purchaseOrderID, int userID, string orderDate, string supplierID, float totalAmount)
        {
            this.purchaseOrderID = purchaseOrderID;
            this.userID = userID;
            this.orderDate = orderDate;
            this.supplierID = supplierID;
            this.totalAmount = totalAmount;
        }
        public int PurchaseOrderID
        {
            get { return purchaseOrderID; }
            set { purchaseOrderID = value; }
        }
        public int UserID { get { return userID; } set { userID = value; } }
        public string OrderDate { get { return orderDate; } set { orderDate = value; } }
        public string SupplierID { get { return supplierID; } set { supplierID = value; } }
        public float TotalAmount { get { return totalAmount; } set { totalAmount = value; } }
    }
}
