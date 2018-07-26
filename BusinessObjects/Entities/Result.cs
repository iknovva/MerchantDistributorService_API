using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
     public class Results<T> 
    {
        public static bool IsSucces { get; set; }
        public static string ErrorMessage { get; set; }
        public static int ErrorCode { get; set; }
        public static T Data { get; set; }
    }
}
