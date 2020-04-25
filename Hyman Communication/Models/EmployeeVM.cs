using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CompID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime DatePromoted { get; set; }
    }
}
