using ClassLibraryEntities;
using System.Text.Json;

namespace DockerPanel.Services
{
    public class DoctorInfoService: IDoctorInfoService
    {
        private readonly HttpClient _httpClient;
        public DoctorInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<EntDoctorInfo>> GetDoctorAuth(EntDoctorInfo ec)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/GetDoctoGetDoctorInfoByUsernameAndPasswordrInfo", ec);
                response.EnsureSuccessStatusCode(); // Throws an exception if the response is not successful

                List<EntDoctorInfo> doctorInfoList = await response.Content.ReadFromJsonAsync<List<EntDoctorInfo>>();
                return doctorInfoList;
            }
            catch (Exception ex)
            {
                // Handle the exception
                // For example, log the error or throw a custom exception
                Console.WriteLine($"Error: {ex.Message}");
                return new List<EntDoctorInfo>();
            }
        }
       
        public async Task<ResponseModel> SaveRegistrationInfo(EntDoctorInfo entDoctorInfo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/SaveRegistrationInfo", entDoctorInfo);
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            catch (Exception ex)
            {
                // Handle the exception
                // For example, log the error or throw a custom exception
                Console.WriteLine($"Error: {ex.Message}");
                return new ResponseModel();
            }
        }

        public async Task<EntDoctorInfo> GetDoctorInfoById(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/GetDoctorInfoById", id);
                response.EnsureSuccessStatusCode(); // Throws an exception if the response is not successful

                string jsonContent = await response.Content.ReadAsStringAsync();
                var elevadoresModels = JsonSerializer.Deserialize<List<EntDoctorInfo>>(jsonContent);
                EntDoctorInfo doctorInfo = elevadoresModels.First();
                return doctorInfo;
            }
            catch (Exception ex)
            {
                // Handle the exception
                // For example, log the error or throw a custom exception
                Console.WriteLine($"Error: {ex.Message}");
                return null; // Return null or throw an exception based on your error handling strategy
            }
        }



        public async Task<ResponseModel> UpdateDoctorInfo(EntDoctorInfo entDoctorInfo)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/UpdateDoctorInfo", entDoctorInfo);
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            catch (Exception ex)
            {
                // Handle the exception
                // For example, log the error or throw a custom exception
                Console.WriteLine($"Error: {ex.Message}");
                return new ResponseModel();
            }
        }


    }
}
