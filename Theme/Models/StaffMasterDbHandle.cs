using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Theme.Models
{
    public class StaffMasterDbHandle
    {



        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
            con = new SqlConnection(constring);
        }
     



        // **************** ADD NEW Staff *********************
        public bool AddStaff(Staff smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pInsertStaffMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StaffName", smodel.StaffName);
            cmd.Parameters.AddWithValue("@HospitalId", smodel.HospitalId);
            cmd.Parameters.AddWithValue("@EmployeeCode", smodel.EmployeeCode);
            cmd.Parameters.AddWithValue("@StaffSpecialization", smodel.StaffSpecialization);
            cmd.Parameters.AddWithValue("@StaffDegree", smodel.StaffDegree);
            cmd.Parameters.AddWithValue("@Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("@StaffPhone", smodel.StaffPhone);
            cmd.Parameters.AddWithValue("@StaffEmail", smodel.StaffEmail);
            cmd.Parameters.AddWithValue("@StaffCity", smodel.StaffCity);
            cmd.Parameters.AddWithValue("@StaffState", smodel.StaffState);
            cmd.Parameters.AddWithValue("@StaffCountry", smodel.StaffCountry);
            cmd.Parameters.AddWithValue("@Status", smodel.Status);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@RoleId", smodel.RoleId);
            cmd.Parameters.AddWithValue("@StaffAddress", smodel.StaffAddress);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Staff DETAILS ********************
        public List<Staff> GetStaff()
        {
            connection();
            List<Staff> Stafflist = new List<Staff>();

            SqlCommand cmd = new SqlCommand("pDetailsStaffMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Stafflist.Add(
                    new Staff
                    {
                        StaffId = Convert.ToInt32(dr["StaffId"]),
                        StaffName = Convert.ToString(dr["StaffName"]),
                        HospitalId = Convert.ToInt32(dr["HospitalId"]),
                        EmployeeCode = Convert.ToInt32(dr["EmployeeCode"]),
                        StaffSpecialization = Convert.ToString(dr["StaffSpecialization"]),
                        StaffDegree = Convert.ToString(dr["StaffDegree"]),
                        Designation = Convert.ToString(dr["Designation"]),

                        StaffPhone = Convert.ToString(dr["StaffPhone"]),
                        StaffEmail = Convert.ToString(dr["StaffEmail"]),
                        StaffCity = Convert.ToString(dr["StaffCity"]),
                        StaffState = Convert.ToString(dr["StaffState"]),
                        StaffCountry = Convert.ToString(dr["StaffCountry"]),
                        Status = Convert.ToString(dr["Status"]),
                        EntryDate = Convert.ToString(dr["EntryDate"]),
                        EntryBy = Convert.ToString(dr["EntryBy"]),
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                        StaffAddress = Convert.ToString(dr["StaffAddress"]),

                    });
            }
            return Stafflist;
        }

        // ***************** UPDATE Staff DETAILS *********************
        public bool UpdateDetails(Staff smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pUpdateStaffMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StaffId", smodel.StaffId);
            cmd.Parameters.AddWithValue("@StaffName", smodel.StaffName);
            cmd.Parameters.AddWithValue("@HospitalId", smodel.HospitalId);
            cmd.Parameters.AddWithValue("@EmployeeCode", smodel.EmployeeCode);
            cmd.Parameters.AddWithValue("@StaffSpecialization", smodel.StaffSpecialization);
            cmd.Parameters.AddWithValue("@StaffDegree", smodel.StaffDegree);
            cmd.Parameters.AddWithValue("@Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("@StaffPhone", smodel.StaffPhone);
            cmd.Parameters.AddWithValue("@StaffEmail", smodel.StaffEmail);
            cmd.Parameters.AddWithValue("@StaffCity", smodel.StaffCity);
            cmd.Parameters.AddWithValue("@StaffState", smodel.StaffState);
            cmd.Parameters.AddWithValue("@StaffCountry", smodel.StaffCountry);
            cmd.Parameters.AddWithValue("@Status", smodel.Status);
            cmd.Parameters.AddWithValue("@EntryDate", Convert.ToDateTime(smodel.EntryDate));
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            cmd.Parameters.AddWithValue("@RoleName", smodel.RoleId);
            cmd.Parameters.AddWithValue("@StaffAddress", smodel.StaffAddress);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Staff DETAILS *******************
        public bool DeleteStaff(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pDeleteStaffMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StaffId", id);

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
