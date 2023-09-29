using ClassLibraryEntities;

namespace DockerPanel.Services
{
    public interface IDoctorInfoService
    {
        Task<List<EntDoctorInfo>> GetDoctorAuth(EntDoctorInfo ec);
        Task<ResponseModel> SaveRegistrationInfo(EntDoctorInfo entDoctorInfo);
        Task<EntDoctorInfo> GetDoctorInfoById(int id);


        Task<ResponseModel> UpdateDoctorInfo(EntDoctorInfo entDoctorInfo);



    }
}
