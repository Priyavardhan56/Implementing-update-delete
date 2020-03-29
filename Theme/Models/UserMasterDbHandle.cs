using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Theme.Models
{
    public class UserMasterDbHandle
    {



        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW User *********************
        public bool AddUser(User smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pInsertUserMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", smodel.UserName);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@RoleId", smodel.RoleId);
            cmd.Parameters.AddWithValue("@HospitalId", smodel.HospitalId);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW User DETAILS ********************
        public List<User> GetUser()
        {
            connection();
            List<User> Userlist = new List<User>();

            SqlCommand cmd = new SqlCommand("pDetailsUserMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Userlist.Add(
                    new User
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        Password = Convert.ToString(dr["Password"]),
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                        HospitalId = Convert.ToInt32(dr["HospitalId"]),
                        EntryBy = Convert.ToString(dr["EntryBy"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        EntryDate = Convert.ToString(dr["EntryDate"])
                    });
            }
            return Userlist;
        }

        // ***************** UPDATE User DETAILS *********************
        public bool UpdateDetails(User smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pUpdateUserMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", smodel.UserId);
            cmd.Parameters.AddWithValue("@UserName", smodel.UserName);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@RoleId", smodel.RoleId);
            cmd.Parameters.AddWithValue("@HospitalId", smodel.HospitalId);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("@EntryDate", Convert.ToDateTime(smodel.EntryDate));

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE User DETAILS *******************
        public bool DeleteUser(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pDeleteUserMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
