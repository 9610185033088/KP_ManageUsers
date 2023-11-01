using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_ManageUsers.Shared
{
    [Table("AccessGroups")]
    public class AccessGroup
    {
        [Key]
        public int AccessGroupID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
