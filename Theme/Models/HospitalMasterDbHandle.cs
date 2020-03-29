using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Theme.Models;


namespace Theme.Models
{
    public class HospitalMasterDbHandle
    {
          private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Hospital *********************
        public bool AddHospital(Hospital smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pInsertHospitalMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
            cmd.Parameters.AddWithValue("@HospitalAddress", smodel.HospitalAddress);
            cmd.Parameters.AddWithValue("@HospitalCity", smodel.HospitalCity);
            cmd.Parameters.AddWithValue("@HospitalState", smodel.HospitalState);
            cmd.Parameters.AddWithValue("@HospitalCountry", smodel.HospitalCountry);
            cmd.Parameters.AddWithValue("@HospitalPhone", smodel.HospitalPhone);
            cmd.Parameters.AddWithValue("@HospitalEmail", smodel.HospitalEmail);
            cmd.Parameters.AddWithValue("@HospitalLogo", smodel.HospitalLogo);
            cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("@EntryDateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Hospital DETAILS ********************
        public List<Hospital> GetHospital()
        {
            connection();
            List<Hospital> Hospitallist = new List<Hospital>();

            SqlCommand cmd = new SqlCommand("pHospitalMasterDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Hospitallist.Add(
                    new Hospital
                    {
                        HospitalId = Convert.ToInt32(dr["HospitalId"]),
                        HospitalName = Convert.ToString(dr["HospitalName"]),
                        HospitalAddress = Convert.ToString(dr["HospitalAddress"]),
                        HospitalCity = Convert.ToString(dr["HospitalCity"]),
                        HospitalState = Convert.ToString(dr["HospitalState"]),
                        HospitalCountry = Convert.ToString(dr["HospitalCountry"]),
                        HospitalPhone = Convert.ToString(dr["HospitalPhone"]),
                        HospitalEmail = Convert.ToString(dr["HospitalEmail"]),
                        HospitalLogo = Convert.ToString(dr["HospitalLogo"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        EntryDateTime = Convert.ToString(dr["EntryDateTime"]),
                        EntryBy = Convert.ToString(dr["EntryBy"])
                    });
            }
            return Hospitallist;
        }

        // ***************** UPDATE Hospital DETAILS *********************
        public bool UpdateDetails(Hospital smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pUPdateHospitalMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@HospitalId", smodel.HospitalId);
            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
            cmd.Parameters.AddWithValue("@HospitalAddress", smodel.HospitalAddress);
            cmd.Parameters.AddWithValue("@HospitalCity", smodel.HospitalCity);
            cmd.Parameters.AddWithValue("@HospitalState", smodel.HospitalState);
            cmd.Parameters.AddWithValue("@HospitalCountry", smodel.HospitalCountry);
            cmd.Parameters.AddWithValue("@HospitalPhone", smodel.HospitalPhone);
            cmd.Parameters.AddWithValue("@HospitalEmail", smodel.HospitalEmail);
            cmd.Parameters.AddWithValue("@HospitalLogo", smodel.HospitalLogo);
            cmd.Parameters.AddWithValue("@IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("@EntryDateTime", Convert.ToDateTime(smodel.EntryDateTime));
            cmd.Parameters.AddWithValue("@EntryBy", smodel.EntryBy);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Hospital DETAILS *******************
        public bool DeleteHospital(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pDeleteHospitalMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@HospitalId", id);

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
