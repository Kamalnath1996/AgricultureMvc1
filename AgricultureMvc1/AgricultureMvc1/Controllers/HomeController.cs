using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AgricultureMvc1.Models;
using Dapper;

namespace BoutoCustomer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult  Index()
        {
            return View();
        }
        public static string _ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public ActionResult SignOut()
        {
            try
            {
                Response.AddHeader("Cache-Control", "no-cache, no-store,must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
                Response.AddHeader("Expires", "0");
                Session.Abandon();
                Session.Clear();
                Response.Cookies.Clear();
                Session.RemoveAll();
                HttpContext.Cache.Remove("menu");
                Session["UserId"] = null;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user,string btname)
        {
            User register = null;
            try
            {
                if (Request.QueryString["UserType"] == "Farmer")
                {
                    user.roleId = "2";
                }
                else if (Request.QueryString["UserType"] == "Customer")
                {
                    user.roleId = "1";
                }
                else
                {
                    return View(user);
                }
                if (ModelState.IsValid)
                {
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@email", user.email);
                    dp.Add("@password", user.password);
                    dp.Add("@FirstName", user.firstName);
                    dp.Add("@LastName", user.lastName);
                    dp.Add("@type", 2);
                    dp.Add("@roleId", user.roleId);
                    dp.Add("@State", user.State);
                    dp.Add("@City", user.City); 
                    dp.Add("@Locality", user.Locality);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        register = connection.Query<User>("Authentication", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (register.Id == 1)
                    {
                        TempData["message"] = "Registation completed. Sign In to continue.";
                        if (Request.QueryString["UserType"] == "Farmer")
                        {
                            return Redirect("/Home/Login?UserType=Farmer");
                        }
                        else if (Request.QueryString["UserType"] == "Customer")
                        {
                            return Redirect("/Home/Login?UserType=Customer");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Email Id already Exist.";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return View();
        }
        public ActionResult UpdateRegister(User register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@Id", register.Id);
                    dp.Add("@email", register.email);
                    dp.Add("@password", register.password);
                    dp.Add("@FirstName", register.firstName);
                    dp.Add("@LastName", register.lastName);
                    dp.Add("@type", 2);
                    dp.Add("@roleId", register.roleId);
                    dp.Add("@State", register.State);
                    dp.Add("@City", register.City);
                    dp.Add("@Locality", register.Locality);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        register = connection.Query<User>("Authentication", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (register.Id == 1)
                    {

                        return RedirectToAction("SignOut", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Email Id already Exist.";
                        return RedirectToAction("MyAccount");
                    }

                }
                else
                {
                    return RedirectToAction("MyAccount");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("MyAccount");
        }
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(User login)
        {
            if (Request.QueryString["UserType"] == "Farmer")
            {
                login.roleId = "2";
            }
            else if (Request.QueryString["UserType"] == "Customer")
            {
                login.roleId = "1";
            }
            else
            {
                login.roleId = "0";
            }
            User user = null;
            try
            {
                if (!string.IsNullOrEmpty(login.email) && !string.IsNullOrEmpty(login.password))
                {
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@email", login.email);
                    dp.Add("@password", login.password);
                    dp.Add("@type", 1);
                    dp.Add("@roleId", login.roleId);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        user = connection.Query<User>("Authentication", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (user.Id != 0)
                    {
                        Session["UserId"] = user.Id;
                        Session["UserName"] = user.firstName + " " + user.lastName;
                        Session["email"] = user.email;
                        Session["role"] = user.roleId;
                        var r = Request.UrlReferrer;
                        return RedirectToAction("FarmerMarket", "Products");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Email or Password.";
                        return View();
                    }

                }
                else
                {
                    TempData["message"] = "Enter Email and Password";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View();
        }
        public List<SelectListItem> state()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Andaman & Nicobar Islands", Value = "Andaman & Nicobar Islands" });
            items.Add(new SelectListItem { Text = "Andhra Pradesh", Value = "Andhra Pradesh" });
            items.Add(new SelectListItem { Text = "Arunachal Pradesh", Value = "Arunachal Pradesh" });
            items.Add(new SelectListItem { Text = "Bihar", Value = "Bihar" });
            items.Add(new SelectListItem { Text = "Chandigarh", Value = "Chandigarh" });
            items.Add(new SelectListItem { Text = "Chhattisgarh", Value = "Chhattisgarh" });
            items.Add(new SelectListItem { Text = "Dadra & Nagar Haveli", Value = "Dadra & Nagar Haveli" });
            items.Add(new SelectListItem { Text = "Daman and Diu", Value = "Daman and Diu" });
            items.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            items.Add(new SelectListItem { Text = "Goa", Value = "Goa" });
            items.Add(new SelectListItem { Text = "Gujarat", Value = "Gujarat" });
            items.Add(new SelectListItem { Text = "Haryana", Value = "Haryana" });
            items.Add(new SelectListItem { Text = "Himachal Pradesh", Value = "Himachal Pradesh" });
            items.Add(new SelectListItem { Text = "Jammu & Kashmir", Value = "Jammu & Kashmir" });
            items.Add(new SelectListItem { Text = "Jharkhand", Value = "Jharkhand" });
            items.Add(new SelectListItem { Text = "Karnataka", Value = "Karnataka" });
            items.Add(new SelectListItem { Text = "Kerala", Value = "Kerala" });
            items.Add(new SelectListItem { Text = "Lakshadweep", Value = "Lakshadweep" });
            items.Add(new SelectListItem { Text = "Madhya Pradesh", Value = "Madhya Pradesh" });
            items.Add(new SelectListItem { Text = "Maharashtra", Value = "Maharashtra" });
            items.Add(new SelectListItem { Text = "Manipur", Value = "Manipur" });
            items.Add(new SelectListItem { Text = "Meghalaya", Value = "Meghalaya" });
            items.Add(new SelectListItem { Text = "Mizoram", Value = "Mizoram" });
            items.Add(new SelectListItem { Text = "Nagaland", Value = "Nagaland" });
            items.Add(new SelectListItem { Text = "Odisha", Value = "Odisha" });
            items.Add(new SelectListItem { Text = "Puducherry", Value = "Puducherry" });
            items.Add(new SelectListItem { Text = "Punjab", Value = "Punjab" });
            items.Add(new SelectListItem { Text = "Rajasthan", Value = "Rajasthan" });
            items.Add(new SelectListItem { Text = "Sikkim", Value = "Sikkim" });
            items.Add(new SelectListItem { Text = "Tamil Nadu", Value = "Tamil Nadu" });
            items.Add(new SelectListItem { Text = "Telangana", Value = "Telangana" });
            items.Add(new SelectListItem { Text = "Tripura", Value = "Tripura" });
            items.Add(new SelectListItem { Text = "Uttarakhand", Value = "Uttarakhand" });
            items.Add(new SelectListItem { Text = "Uttar Pradesh", Value = "Uttar Pradesh" });
            items.Add(new SelectListItem { Text = "West Bengal", Value = "West Bengal" });

            return items;
        }
        public ActionResult MyAccount()
        {
            User user = new User();
            if (Session["UserId"] != null)
            {
                int Id = Convert.ToInt32(Session["UserId"]);
                try
                {
                    List<SelectListItem> statelist = state();
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("@Id", Convert.ToInt32(Session["UserId"]));
                    dp.Add("@type", 3);
                    using (IDbConnection connection = new SqlConnection(_ConStr))
                    {
                        user = connection.Query<User>("Authentication", dp, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    if (user == null)
                    {
                        user = new User();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else
            {
               return Redirect("/Home/Login");
            }
            return View(user);
        }
        public JsonResult Cateories()
        {
            List<Category> categories = new List<Category>();
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@type", 6);
            using (IDbConnection connection = new SqlConnection(_ConStr))
            {
                categories = connection.Query<Category>("Add_Remove_Select_Edit_Product", dp, commandType: CommandType.StoredProcedure).ToList();
            }
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}