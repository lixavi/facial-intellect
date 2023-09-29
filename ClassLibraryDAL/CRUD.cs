using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntities;
namespace ClassLibraryDAL
{
    public class CRUD
    {
        public static void SaveData(string Procedurename, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Procedurename, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }
        public static async Task<EntDoctorInfo> DockerAuth(EntDoctorInfo ec)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DockerAuth", con);
            cmd.Parameters.AddWithValue("@username", ec.username);
            cmd.Parameters.AddWithValue("@password", ec.password);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntDoctorInfo c = new EntDoctorInfo();
            while (sdr.Read())
            {

                c.id = int.Parse(sdr["id"].ToString());
                c.first_name = sdr["first_name"].ToString();

            }
            con.Close();
            return c;

        }
        public static async Task<EntDoctorInfo> GetDoctorInfoByID(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetDoctorInfo", con);
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntDoctorInfo c = new EntDoctorInfo();
            while (sdr.Read())
            {
                c.id = int.Parse(sdr["id"].ToString());
                c.first_name = sdr["first_name"].ToString();
                c.last_name = sdr["last_name"].ToString();
                c.specialization = sdr["specialization"].ToString();
                c.phone_number = sdr["phone_number"].ToString();
                c.email = sdr["email"].ToString();
                c.address = sdr["address"].ToString();
                c.username = sdr["username"].ToString();
                c.password = sdr["password"].ToString();


            }
            con.Close();
            return c;

        }
        public static void UpdateData(string ProcedureName, SqlParameter[] sqlParameters)
        {

            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(ProcedureName, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }




        }
        public static async Task<EntDoctorInfo> GetDoctorInfo(EntDoctorInfo ec)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DockerAuth", con);
            cmd.Parameters.AddWithValue("@id", ec.id);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntDoctorInfo c = new EntDoctorInfo();
            while (sdr.Read())
            {

                c.id = int.Parse(sdr["id"].ToString());
                c.first_name = sdr["first_name"].ToString();
                c.last_name = sdr["last_name"].ToString();
                c.specialization = sdr["specialization"].ToString();
                c.phone_number = sdr["phone_number"].ToString();
                c.email = sdr["email"].ToString();
                c.address = sdr["address"].ToString();
                c.username = sdr["username"].ToString();
                c.password = sdr["password"].ToString();


            }
            con.Close();
            return c;

        }
    }


}
