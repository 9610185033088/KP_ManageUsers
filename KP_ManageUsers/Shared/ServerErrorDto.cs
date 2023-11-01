using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_ManageUsers.Shared
{
    public class ServerErrorDto
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; } = "";
    }
}
