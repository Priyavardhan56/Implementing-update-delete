using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Theme.Models
{
    public class RoleMasterDbHandle
    {



        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Role *********************
        public bool AddRole(Role smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pInsertRoleMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RoleName", smodel.RoleName);
            cmd.Parameters.AddWithValue("@RoleDescription", smodel.RoleDescription);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@EntryDateTime", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Role DETAILS ********************
        public List<Role> GetRole()
        {
            connection();
            List<Role> Rolelist = new List<Role>();

            SqlCommand cmd = new SqlCommand("pDetailsRoleMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Rolelist.Add(
                    new Role
                    {
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                        RoleName = Convert.ToString(dr["RoleName"]),
                        RoleDescription = Convert.ToString(dr["RoleDescription"]),
                        EntryBy = Convert.ToString(dr["EntryBy"]),
                        EntryDateTime = Convert.ToString(dr["EntryDateTime"])
                    });
            }
            return Rolelist;
        }

        // ***************** UPDATE Role DETAILS *********************
        public bool UpdateDetails(Role smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pUpdateRoleMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RoleId", smodel.RoleId);
            cmd.Parameters.AddWithValue("@RoleName", smodel.RoleName);
            cmd.Parameters.AddWithValue("@RoleDescription", smodel.RoleDescription);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@EntryDateTime", Convert.ToDateTime(smodel.EntryDateTime));

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Role DETAILS *******************
        public bool DeleteRole(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pDeleteRoleMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RoleId", id);

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
