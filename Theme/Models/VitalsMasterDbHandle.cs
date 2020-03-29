using System;
using Theme.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Theme.Models
{
    public class VitalsMasterDbHandle
    {



        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Vitals *********************
        public bool AddVitals(Vitals smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pInsertVitalsMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DoctorName", smodel.DoctorName);
            cmd.Parameters.AddWithValue("@PatientName", smodel.PatientName);
            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
            cmd.Parameters.AddWithValue("@BloodPressure", smodel.BloodPressure);
            cmd.Parameters.AddWithValue("@Temperature", smodel.Temperature);
            cmd.Parameters.AddWithValue("@Pulse", smodel.Pulse);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Vitals DETAILS ********************
        public List<Vitals> GetVitals()
        {
            connection();
            List<Vitals> Vitalslist = new List<Vitals>();

            SqlCommand cmd = new SqlCommand("pDetailsVitalsMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Vitalslist.Add(
                    new Vitals
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        DoctorName = Convert.ToString(dr["DoctorName"]),
                        PatientName = Convert.ToString(dr["patientName"]),
                        HospitalName = Convert.ToString(dr["HospitalName"]),
                        BloodPressure = Convert.ToString(dr["BloodPressure"]),
                        Temperature = Convert.ToString(dr["Temperature"]),
                        Pulse = Convert.ToString(dr["Pulse"]),
                        EntryDate = Convert.ToString(dr["EntryDate"])
                    });
            }
            return Vitalslist;
        }

        // ***************** UPDATE Vitals DETAILS *********************
        public bool UpdateDetails(Vitals smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pUpdateVitalsMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", smodel.Id);
            cmd.Parameters.AddWithValue("@DoctorName", smodel.DoctorName);
            cmd.Parameters.AddWithValue("@PatientName", smodel.PatientName);
            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
            cmd.Parameters.AddWithValue("@BloodPressure", smodel.BloodPressure);
            cmd.Parameters.AddWithValue("@Temperature", smodel.Temperature);
            cmd.Parameters.AddWithValue("@Pulse", smodel.Pulse);
            cmd.Parameters.AddWithValue("@EntryDate", Convert.ToDateTime(smodel.EntryDate));

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Vitals DETAILS *******************
        public bool DeleteVitals(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("pDeleteVitalsMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VitalsId", id);

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
