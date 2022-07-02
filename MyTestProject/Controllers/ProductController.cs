using MyTestProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestProject.Controllers
{
    public class ProductController : Controller
    {
        SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                DataTable dtDetails = new DataTable();
                SqlCommand cmd = new SqlCommand("GetAllItem");
                cmd.CommandType = CommandType.StoredProcedure;
                dtDetails = DataConnection.GetData(cmd);
                return View(dtDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            
        }

        // GET: Product/Details/5
        [HttpPost]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            //ProductModel obj = new ProductModel();
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                // TODO: Add insert logic here
                SqlCommand cmd = new SqlCommand("AddNewItem");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", productModel.Name);
                cmd.Parameters.AddWithValue("@Description", productModel.Description);
                cmd.Parameters.AddWithValue("@Quntity", productModel.Quntity);
                cmd.Parameters.AddWithValue("@Price", productModel.Price);
                cmd.Parameters.AddWithValue("@SupplierName", productModel.SupplierName);
                DataConnection.Execute(cmd);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel obj = new ProductModel();
            SqlCommand cmd = new SqlCommand("GetItemByID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            DataTable dtDetails = DataConnection.GetData(cmd);
            if(dtDetails.Rows.Count>0)
            {
                obj.ID = Convert.ToInt32(dtDetails.Rows[0]["ID"]);
                obj.Name = Convert.ToString(dtDetails.Rows[0]["Name"]);
                obj.Description = Convert.ToString(dtDetails.Rows[0]["Description"]);
                obj.Quntity = Convert.ToDouble(dtDetails.Rows[0]["Quntity"]);
                obj.Price = Convert.ToDouble(dtDetails.Rows[0]["Price"]);
                obj.SupplierName = Convert.ToString(dtDetails.Rows[0]["SupplierName"]);
                return View(obj);
            }else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel pm)
        {
            try
            {
                // TODO: Add update logic here
                SqlCommand cmd = new SqlCommand("UpdateItem");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", pm.Name);
                cmd.Parameters.AddWithValue("@Description", pm.Description);
                cmd.Parameters.AddWithValue("@Quntity", pm.Quntity);
                cmd.Parameters.AddWithValue("@Price", pm.Price);
                cmd.Parameters.AddWithValue("@SupplierName", pm.SupplierName);
                cmd.Parameters.AddWithValue("@ID", pm.ID);
                DataConnection.Execute(cmd);
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
            SqlCommand cmd = new SqlCommand("DeleteItemByID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            DataConnection.Execute(cmd);
            return RedirectToAction("Index");

        }

    }
}
