using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_ManageUsers.Shared
{
    [Table("Users")]
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
    }
}
