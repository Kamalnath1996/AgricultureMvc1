using AgricultureMvc1.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutoCustomer.Controllers
{
    public class ProductsController :Controller
    {
        public static string _ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        Product product = new Product();
        List<Product> products = new List<Product>();
        List<Cart> cart = new List<Cart>();
        public ActionResult FarmerMarket(string categories_id)
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@categoryId", categories_id);
                dp.Add("@type", String.IsNullOrEmpty(categories_id) || categories_id.Equals("0")?2:4);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    products = connection.Query<Product>("Add_Remove_Select_Edit_Product", dp, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View(products);
        }
        public ActionResult Save_product(string ProductId)
        {
            if (Session["UserId"]!= null && Session["role"].ToString() == "2")
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@type", 2);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    products = connection.Query<Product>("Add_Remove_Select_Edit_Product", dp, commandType: CommandType.StoredProcedure).ToList();
                }
                DynamicParameters dp2 = new DynamicParameters();
                dp2.Add("@type", 6);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    List<Category> cat = connection.Query<Category>("Add_Remove_Select_Edit_Product", dp2, commandType: CommandType.StoredProcedure).ToList();
                    ViewBag.categories = cat;
                }
                ViewBag.Products = products;
                if (!String.IsNullOrEmpty(ProductId))
                {
                    DynamicParameters dp1 = new DynamicParameters();
                    dp1.Add("@type", 3);
                    dp1.Add("@Id", ProductId);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        product = connection.Query<Product>("Add_Remove_Select_Edit_Product", dp1, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                }
                return View(product);
            }else
            {
                return Redirect("/Home/Login?UserType=Farmer");
            }
        }
        [HttpPost]
        public ActionResult Save_product(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase image = HttpContext.Request.Files[0];
                    string image_filename = string.Empty;
                    string basepath = HttpContext.Server.MapPath("~/Assets1/Images/");
                    string imageurl = null;
                    if (!string.IsNullOrEmpty(image.FileName))
                    {
                        image_filename = DateTime.Now.ToString("ddMMyyyyHHmmss") + image.FileName;
                        imageurl = Request.Url.Scheme + "://" + Request.Url.Authority + "/Assets1/Images/" + image_filename;
                        image.SaveAs(basepath + image_filename);
                        product.productImage = imageurl;
                    }
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@Id", product.Id);
                    dp.Add("@productName", product.productName);
                    dp.Add("@productImage", product.productImage);
                    dp.Add("@productWeight", product.productWeight);
                    dp.Add("@type", 1);
                    dp.Add("@productUnit", product.productUnit);
                    dp.Add("@productQuantity", product.productQuantity);
                    dp.Add("@productPrice", product.productPrice);
                    dp.Add("@categoryId", product.categoryId);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        product = connection.Query<Product>("Add_Remove_Select_Edit_Product", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (product.Id != 0)
                    {
                        TempData["message"] = "Product saved";
                    }
                    else
                    {
                        ViewBag.Message = "Product does not save.";
                        return View();
                    }
                }
                else
                {
                    Redirect("/Products/Save_product");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            DynamicParameters dp1 = new DynamicParameters();
            dp1.Add("@type", 2);
            using (IDbConnection connection = new SqlConnection(_ConStr))
            {
                products = connection.Query<Product>("Add_Remove_Select_Edit_Product", dp1, commandType: CommandType.StoredProcedure).ToList();
            }
            ViewBag.Products = products;
            return Redirect("/Products/Save_product");
        }
        public ActionResult Add_Cart(string ProductId)
        {
            if (Session["UserId"] == null)
            {
                return Redirect("/Home/Index");
            }
            try
            {
                bool result = false;
                int customers_id = Convert.ToInt32(Session["UserId"]);
                if (!string.IsNullOrEmpty(ProductId))
                {
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@ProductId", ProductId);
                    dp.Add("@userId", customers_id);
                    dp.Add("@type", 1);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        result = connection.Query<bool>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (result)
                    {
                        return RedirectToAction("FarmerMarket");
                    }
                    else
                    {
                        return Redirect(Request.UrlReferrer.PathAndQuery);
                    }
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Redirect("/Home/Index");
        }
        public ActionResult delete_Cart(int CartId)
        {
            try
            {
                bool result = false;
                int customers_id = Convert.ToInt32(Session["UserId"]);
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@Id", CartId);
                dp.Add("@type", 4);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    result = connection.Query<bool>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                if (result)
                {
                    return RedirectToAction("Cart");
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Redirect("/Home/Index");
        }
        public ActionResult Delete_product(int ProductId)
        {
            try
            {
                bool result = false;
                int customers_id = Convert.ToInt32(Session["UserId"]);
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@Id", ProductId);
                dp.Add("@type", 5);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    result = connection.Query<bool>("Add_Remove_Select_Edit_Product", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                if (result)
                {
                    return RedirectToAction("Save_product");
                }
                else
                {
                    return Redirect("Save_product");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Redirect("Save_product");
        }
        public ActionResult Cart()
        {
            try
            {
                int customers_id = Convert.ToInt32(Session["UserId"]);
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@userId", customers_id);
                dp.Add("@type", 3);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    cart = connection.Query<Cart>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).ToList();
                }
                if (cart.Count > 0)
                {
                    decimal Sub_Total = 0;
                    foreach (var item in cart)
                    {
                        Sub_Total = Sub_Total + (item.quantity * item.productPrice);
                    }
                    cart[0].SubTotal = Sub_Total;
                    cart[0].Total = Sub_Total;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View(cart);
        }
        public ActionResult add_product_count(int ProductId)
        {
            try
            {
                bool result = false;
                int customers_id = Convert.ToInt32(Session["UserId"]);
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@ProductId", ProductId);
                dp.Add("@userId", customers_id);
                dp.Add("@type", 1);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    result = connection.Query<bool>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult remove_product_count(int ProductId)
        {
            try
            {
                bool result = false;
                int customers_id = Convert.ToInt32(Session["UserId"]);
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@ProductId", ProductId);
                dp.Add("@userId", customers_id);
                dp.Add("@type", 2);
                using (IDbConnection connection = new SqlConnection(_ConStr))
                {
                    result = connection.Query<bool>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Cart");
        }  
        public ActionResult Place_Order(string amount)
        {
            ViewBag.amount = amount;
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Id", Convert.ToInt32(Session["UserId"]));
            dp.Add("@type", 5);
            using (IDbConnection connection = new SqlConnection(_ConStr))
            {
                bool result = connection.Query<bool>("Add_Remove_Select_Delete_cart", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return View();
        }
    }
}