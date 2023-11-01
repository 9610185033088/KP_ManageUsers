using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_ManageUsers.Shared
{
    [Table("UserGroups")]
    public class UserGroup : AuditableEntity
    {
        public int UserID { get; set; }
        public int AccessGroupID { get; set; }
        public User? User { get; set; }
        public AccessGroup? AccessGroup { get; set; }
    }
}
