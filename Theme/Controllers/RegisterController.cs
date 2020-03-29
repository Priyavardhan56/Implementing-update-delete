using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theme.Models;
using System.Data.SqlClient;
using System.Data;

namespace Theme.Controllers
{
    public class RegisterController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Register obj)
        {

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("pValidateUser");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                Session["Id"] = ds.Tables[0].Rows[0]["Id"].ToString();
                return RedirectToAction("Create", "RoleMaster");
            }

            //if (sdr.Read())
            //{
            //    //FormsAuthentication.SetAuthCookie(obj.Username, true);
                

            //    return RedirectToAction("index", "Home");
            //}
            else
            {
                ViewData["Message"] = "User Login Details Failed";
            }
            con.Close();
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Register obj)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");


            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegisterMaster(Name,Email,Password) values(@Name,@Email,@Password)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.ExecuteNonQuery();
            
            return RedirectToAction("Login", "Register");
        }
        // GET: Registration/Details/5`0
        public ActionResult ForgetPassword()
        {
            return View();
        }
       
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Home");
        }


    }
}

