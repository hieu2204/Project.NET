using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyBanHang
{
    public class Connect
    {
        public SqlConnection connect;
        string constr = "Data Source=DESKTOP-VDPSTNV;Initial Catalog=QuanLyBanHang;User ID=sa;Password=123456;TrustServerCertificate=True";

        public Connect()
        {
            connect = new SqlConnection(constr);
        }
        #region CRUD Employee
        public void insertEmployee(int userid,string user,string password,string name,string role,string gender,string birth,string address,string phone,string email)
        {
            try
            {
                connect.Open();
                string sql = "INSERT INTO Users(UserID, Username, Password, Name, Role, Gender, Birthday, Address, Phone, Email) VALUES (@UserID, @Username, @Password, @Name, @Role, @Gender, @Birthday, @Address, @Phone, @Email)";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.Parameters.AddWithValue("@UserID", userid);
                cmd.Parameters.AddWithValue("@Username", user);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Birthday", birth);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                 //Thực thi câu lệnh
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public List<UserEmployee> GetUser()
        {
            List<UserEmployee> userList = new List<UserEmployee>();
            try
            {
                connect.Open();
                string sql = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read()) // Duyệt qua từng dòng dữ liệu
                {
                    UserEmployee user = new UserEmployee();
                    user.UserID = rd.GetInt32(0); // Lấy UserID chỉ số là 0
                    user.User = rd.GetString(1); // Lấy Username chỉ số 1.
                    user.Password = rd.GetString(2); // Lấy Password chỉ số 2.
                    user.Name = rd.GetString(3); // Lấy Role chỉ số 3.
                    user.Role = rd.IsDBNull(4) ? "" : rd.GetString(4);         // Kiểm tra NULL cho Name
                    user.Gender = rd.IsDBNull(5) ? "" : rd.GetString(5);       // Kiểm tra NULL cho Gender
                    user.Birthday = rd.IsDBNull(6) ? "" : rd.GetString(6);     // Kiểm tra NULL cho Birthday
                    user.Address = rd.IsDBNull(7) ? "" : rd.GetString(7);      // Kiểm tra NULL cho Address
                    user.Phone = rd.IsDBNull(8) ? "" : rd.GetString(8);        // Kiểm tra NULL cho Phone
                    user.Email = rd.IsDBNull(9) ? "" : rd.GetString(9);      // Kiểm tra NULL cho Email
                    userList.Add(user);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return userList;
        }
        //public DataSet GetData()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        connect.Open();
        //        string query = "SELECT * FROM Users";
        //        SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
        //        adapter.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi : " + ex.Message);
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //    return ds;
        //}
        public void DeleteUser(int rowIndex)
        {
            try
            {
                connect.Open();
                string delete = "DELETE FROM Users WHERE UserID = @userid";
                SqlCommand cmd = new SqlCommand(delete, connect);
                cmd.Parameters.AddWithValue("@userid", rowIndex);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Delete: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public void UpdateUser(int id,string user,string pass,string role,string name,string gender,string birth,string address,string phone,string email)
        {
            try
            {
                connect.Open();
                String update = "UPDATE Users SET Username = @user, Password = @pass, Role = @role, Name = @name, Gender = @gender, Birthday = @birth, Address = @address, Phone = @phone, Email = @email WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(update, connect);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@birth", birth);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                Console.WriteLine("lỗi: " + ex.Message);
                MessageBox.Show("Lỗi:"+ ex.Message);
            }
            finally
            {
                connect.Close();
            }
            #endregion

        #region CRUD Supplier
        }
        public void InsertSupplier(string id, string name,string email, string phone,string status)
        {
            try
            {
                connect.Open();
                string query = "INSERT INTO Suppliers(SupplierID, SupplierName, Email, Phone, Status) VALUES(@id, @name, @email, @phone, @status)";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("status", status);
                cmd.ExecuteNonQuery();
            }catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
            finally 
            { 
                connect.Close(); 
            }
        }
        public List<Supplier> getSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                connect.Open();
                string query = "SELECT * FROM Suppliers";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = rd.GetString(0);
                    supplier.SupplierName = rd.GetString(1);
                    supplier.Email = rd.GetString(2);
                    supplier.Phone = rd.GetString(3);
                    supplier.Status = rd.GetString(4);
                    suppliers.Add(supplier);
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Lỗi "+ ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return suppliers;
        }
        public void UpdateSupplier(string id, string name, string email,string phone, string status)
        {
            try
            {
                connect.Open();
                string query = "UPDATE Suppliers SET SupplierName = @name, Email = @email, Phone = @phone, Status = @status WHERE SupplierID = @id";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine("Error update supplier: "+ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public void UpdateSupplier(string id, string status)
        {
            try
            {
                connect.Open();
                string query = "UPDATE Suppliers SET Status = @status WHERE SupplierID = @id";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine("Error delete supplier: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public List<Supplier> getSupplierHopTac(string status)
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                connect.Open();
                string query = "SELECT * FROM Suppliers WHERE Status = @status ";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@status", status);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = rd.GetString(0);
                    supplier.SupplierName = rd.GetString(1);
                    supplier.Email = rd.GetString(2);
                    supplier.Phone = rd.GetString(3);
                    supplier.Status = rd.GetString(4);
                    suppliers.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return suppliers;
        }
        public List<Supplier> getSupplierNgungHopTac(string status)
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                connect.Open();
                string query = "SELECT * FROM Suppliers WHERE Status = @status";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@status", status );
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = rd.GetString(0);
                    supplier.SupplierName = rd.GetString(1);
                    supplier.Email = rd.GetString(2);
                    supplier.Phone = rd.GetString(3);
                    supplier.Status = rd.GetString(4);
                    suppliers.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return suppliers;
        }
        #endregion
        #region CRUD Product
        public void InsertOrderDetail(int orderdetailid, int purchaseorderid, string productid, int quantity, float unitcost, float totalcost, float sellingprice)
        {
            try
            {
                connect.Open();
                string query = "INSERT INTO PurchaseOrderDetails(OrderDetailID, PurchaseOrderID, ProductID, Quantity, UnitCost, TotalCost, SellingPrice) VALUES (@orderdetailid, @purchaseorderdetailid, @productid, @quantity, @unitcost, @totalcost, @sellingprice)";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@orderdetailid", orderdetailid);
                cmd.Parameters.AddWithValue("@purchaseorderdetailid", orderdetailid);
                cmd.Parameters.AddWithValue("@productid", productid);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitcost", unitcost);
                cmd.Parameters.AddWithValue("@totalcost",  totalcost);
                cmd.Parameters.AddWithValue("@sellingprice",  sellingprice);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error insert product:" + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public void InsertPurchaseOrder(int purchaseorderid,int userid,string orderdate,string supperid, string supplierid, float totalamount)
        {
            try
            {
                connect.Open();
                string query = "INSERT INTO PurchaseOrders(PurchaseOrderID, UserID, OrderDate, SupplierID, TotalAmount) VALUES (@purchaseorderid, @userid, @orderdate, @supplierid, @totalamount)";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); 
            }
            finally
            {
                connect.Close();
            }
        }
        public List<PurchaseOrder> GetPurchaseOrders()
        {
            List<PurchaseOrder> lst = new List<PurchaseOrder>();
            try
            {
                connect.Open();
                string query = "SELECT * FROM PurchaseOrders";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    PurchaseOrder purchaseOrder = new PurchaseOrder();
                    purchaseOrder.PurchaseOrderID = rd.GetInt32(0);
                    purchaseOrder.UserID = rd.GetInt32(1);
                    purchaseOrder.OrderDate = rd.GetString(2);
                    purchaseOrder.SupplierID = rd.GetString(3);
                    purchaseOrder.TotalAmount = rd.GetFloat(4);
                    lst.Add(purchaseOrder);
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return lst;
        }
        #endregion
    }
}
