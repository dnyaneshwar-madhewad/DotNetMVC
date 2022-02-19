using ProductMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            SqlCommand cmdAllProduct = new SqlCommand();
            cmdAllProduct.Connection = cn;
            cmdAllProduct.CommandType = System.Data.CommandType.Text;
            cmdAllProduct.CommandText = "Select * from Products";
            List<Product> prod = new List<Product>();
            try
            {
                SqlDataReader dr = cmdAllProduct.ExecuteReader();
                while (dr.Read())
                {
                    prod.Add(new Product
                    {
                        Id = (int)dr["Id"],
                        ProductName = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Rate = (Decimal)dr["Rate"],
                        CategoryName = dr["CategoryName"].ToString()



                    });
                 }
                dr.Close();
            }
            catch(Exception e)
            {
                ViewBag.msg = e.Message;
            }
            cn.Close();
            return View(prod);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            SqlCommand cmdAllProduct = new SqlCommand();
            cmdAllProduct.Connection = cn;
            cmdAllProduct.CommandType = System.Data.CommandType.Text;
            cmdAllProduct.CommandText = "Select * from Products where Id=@id";
            Product pro = null;
            try 
            {
                SqlDataReader dr = cmdAllProduct.ExecuteReader();
                if (dr.Read()) 
                {
                     pro=new Product {
                         ProductName = dr["Name"].ToString(),
                         Description = dr["Description"].ToString(),
                         Rate = (Decimal)dr["Rate"],
                         CategoryName = dr["CategoryName"].ToString()
                     };
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            cn.Close();
            return View(pro);
       
        }

        // GET: Product/Create
        public ActionResult Create()
        {
          

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product ProductMvc)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            SqlCommand cmdInsertProduct = new SqlCommand();
            cmdInsertProduct.Connection = cn;
            cmdInsertProduct.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertProduct.CommandText = "Insert";
            cmdInsertProduct.Parameters.AddWithValue("@Name", ProductMvc.ProductName);
            cmdInsertProduct.Parameters.AddWithValue("@Description", ProductMvc.Description);
            cmdInsertProduct.Parameters.AddWithValue("@Rate", ProductMvc.Rate);
            try
            {
                cmdInsertProduct.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }

            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
