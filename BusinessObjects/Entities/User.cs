using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
    public class User
    {
        public string MobileNumber { get; set; }
        public string Password { get; set; }       
    }
    public class Registration:User {
        public string FullName { get; set; }
        public string EmaillAddress { get; set; }
    }
    public class AddressDetails
    {
        public int UserId { get; set; }
        public string Building_Name { get; set; }
        public string Locality { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Landmark { get; set; }
        public string AddressType { get; set; }
    }
    public class CompanyDetails
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string GST_No { get; set; }
        public string Category { get; set; }
        public string Businees_Type { get; set; }
    }
}
