using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    internal class User
    {
        public string? LibraryCardID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }=true;
    }
}
