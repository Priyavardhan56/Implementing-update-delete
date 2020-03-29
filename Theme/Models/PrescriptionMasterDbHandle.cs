//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;

//namespace Theme.Models
//{
//    public class PrescriptionMasterDbHandle
//    {



//        private SqlConnection con;

//        private void connection()
//        {
//            string constring = ConfigurationManager.ConnectionStrings["Roleconn"].ToString();
//            con = new SqlConnection(constring);
//        }

//        // **************** ADD NEW Role *********************
//        public bool AddRole(Role smodel)
//        {
//            connection();
//            SqlCommand cmd = new SqlCommand("pInsertPrescriptionMaster", con);
//            cmd.CommandType = CommandType.StoredProcedure;

//            cmd.Parameters.AddWithValue("@DoctorName", smodel.DoctorName);
//            cmd.Parameters.AddWithValue("@PatientName", smodel.PatientName);
//            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
//            cmd.Parameters.AddWithValue("@Symptoms", smodel.Symptoms);
//            cmd.Parameters.AddWithValue("@Diagnosis", smodel.Diagnosis);
//            cmd.Parameters.AddWithValue("@Remarks", smodel.Remarks);
//            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
//            cmd.Parameters.AddWithValue("@ReferTo", smodel.ReferTo);
//            cmd.Parameters.AddWithValue("@ReferRemarks", smodel.ReferRemarks);

//            con.Open();
//            int i = cmd.ExecuteNonQuery();
//            con.Close();

//            if (i >= 1)
//                return true;
//            else
//                return false;
//        }

//        // ********** VIEW Role DETAILS ********************
//        public List<Role> GetRole()
//        {
//            connection();
//            List<Role> Rolelist = new List<Role>();

//            SqlCommand cmd = new SqlCommand("pDetailsPrescriptionMaster", con);
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter sd = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();

//            con.Open();
//            sd.Fill(dt);
//            con.Close();

//            foreach (DataRow dr in dt.Rows)
//            {
//                Rolelist.Add(
//                    new Role
//                    {
//                        PrescriptionId = Convert.ToInt32(dr["PrescriptionId"]),
//                        DoctorName = Convert.ToString(dr["DoctorName"]),
//                        PatientName = Convert.ToString(dr["PatientName"]),
//                        HospitalName = Convert.ToString(dr["HospitalName"]),
//                        Symptoms = Convert.ToString(dr["Symptoms"]),
//                        Diagnosis = Convert.ToString(dr["Diagnosis"]),
//                        Remarks = Convert.ToString(dr["Remarks"]),
//                        EntryDate = Convert.ToString(dr["EntryDate"])
//                        ReferTo = Convert.ToString(dr["ReferTo"]),
//                        ReferRemarks = Convert.ToString(dr["ReferRemarks"]),

//                    });
//            }
//            return Rolelist;
//        }

//        // ***************** UPDATE Role DETAILS *********************
//        public bool UpdateDetails(User smodel)
//        {
//            connection();
//            SqlCommand cmd = new SqlCommand("pUpdateVitalMaster", con);
//            cmd.CommandType = CommandType.StoredProcedure;

//            cmd.Parameters.AddWithValue("@PrescriptionId", smodel.PrescriptionId);
//            cmd.Parameters.AddWithValue("@DoctorName", smodel.DoctorName);
//            cmd.Parameters.AddWithValue("@PatientName", smodel.PatientName);
//            cmd.Parameters.AddWithValue("@HospitalName", smodel.HospitalName);
//            cmd.Parameters.AddWithValue("@Symptoms", smodel.Symptoms);
//            cmd.Parameters.AddWithValue("@Diagnosis", smodel.Age);
//            cmd.Parameters.AddWithValue("@Remarks", smodel.Problem);
//            cmd.Parameters.AddWithValue("@EntryDate", Convert.ToDateTime(smodel.EntryDate));
//            cmd.Parameters.AddWithValue("@ReferTo", smodel.ReferTo);
//            cmd.Parameters.AddWithValue("@ReferRemarks", smodel.ReferRemarks);


//            con.Open();
//            int i = cmd.ExecuteNonQuery();
//            con.Close();

//            if (i >= 1)
//                return true;
//            else
//                return false;
//        }

//        // ********************** DELETE Role DETAILS *******************
//        public bool DeleteUser(int id)
//        {
//            connection();
//            SqlCommand cmd = new SqlCommand("pDeletePrescriptionMaster", con);
//            cmd.CommandType = CommandType.StoredProcedure;

//            cmd.Parameters.AddWithValue("@PrescriptionId", id);

//            con.Open();
//            int i = cmd.ExecuteNonQuery();
//            con.Close();

//            if (i >= 1)
//                return true;
//            else
//                return false;
//        }
//    }
//}
