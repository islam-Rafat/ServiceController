using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("DepartmentLocation")]
    public class DepartmentLocation
    {
        [Required]
        [Key, Column(Order = 1)]
        public int DepartmentID { get; set; }

        [Key, Column(Order = 2)]
        public string Location { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}