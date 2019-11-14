using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("DepartmentManager")]
    public class DepartmentManager
    {
        [Key]
        [Required]
        public int ManagerID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public Department Department { get; set; }

        public Employee Employee { get; set; }
    }
}