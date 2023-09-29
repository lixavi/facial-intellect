using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntDoctorInfo
    {
        public int id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? specialization { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
