using ClassLibraryDAL;
using ClassLibraryEntities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class DoctorInfoController : Controller
    {
        [HttpPost]
        [Route("SavaDoctorInfo")]
        public void SaveDoctorInfo(EntDoctorInfo entDoctorInfo)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@first_name",entDoctorInfo.first_name),
                new SqlParameter("@last_name",entDoctorInfo.last_name),
                new SqlParameter("@specialization",entDoctorInfo.specialization),
                new SqlParameter("@phone_number",entDoctorInfo.phone_number),
                new SqlParameter("@email",entDoctorInfo.email),
                new SqlParameter("@address",entDoctorInfo.address),
           
            };
            CRUD.SaveData("SavaDoctorInfo", sqlParameters);

        }
        [HttpPost]
        [Route("SaveRegistrationInfo")]
        public void SaveRegistrationInfo(EntDoctorInfo entDoctorInfo)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@firstname",entDoctorInfo.first_name), 
                new SqlParameter("@username",entDoctorInfo.username),
                new SqlParameter("@password",entDoctorInfo.password),
           
            };
            CRUD.SaveData("SaveRegistrationInfo", sqlParameters);
        }
        [HttpPost]
        [Route("GetDoctoGetDoctorInfoByUsernameAndPasswordrInfo")]
        public async Task<IActionResult> GetDoctorInfoByUsernameAndPassword([FromBody] EntDoctorInfo entDoctorInfo)
        {
            EntDoctorInfo doctorInfo = await ClassLibraryDAL.CRUD.DockerAuth(entDoctorInfo);
            if (doctorInfo != null)
            {
                List<EntDoctorInfo> doctorInfoList = new List<EntDoctorInfo> { doctorInfo };
                return Ok(doctorInfoList);
            }
            else
            {
                return NotFound("Not Found");
            }
        }


        [HttpPut]
        [Route("UpdateDoctorInfo")]
        public void UpdateDoctorInfo(EntDoctorInfo entDoctorInfo)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id",entDoctorInfo.id),
                new SqlParameter("@firstname",entDoctorInfo.first_name),
                new SqlParameter("@lastname",entDoctorInfo.last_name),
                new SqlParameter("@specialization",entDoctorInfo.specialization),
                new SqlParameter("@pno",entDoctorInfo.phone_number),
                new SqlParameter("@email",entDoctorInfo.email),
                new SqlParameter("@address",entDoctorInfo.address),
                new SqlParameter("@username",entDoctorInfo.username),
                new SqlParameter("@password",entDoctorInfo.password),

            };
            CRUD.UpdateData("UpdateDoctorInfo", sqlParameters);
        }

        [HttpPost]
        [Route("GetDoctorInfoById")]
        public async Task<IActionResult> GetDoctorInfoById([FromBody] int id)
        {
            EntDoctorInfo doctorInfo = await ClassLibraryDAL.CRUD.GetDoctorInfoByID(id);
            if (doctorInfo != null)
            {
                List<EntDoctorInfo> doctorInfoList = new List<EntDoctorInfo> { doctorInfo };
                return Ok(doctorInfoList);
            }
            else
            {
                return NotFound("Not Found");
            }
        }


    }
}