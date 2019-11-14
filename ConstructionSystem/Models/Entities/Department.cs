using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Number Of Employees")]
        public int? NumberOfEmps { get; set; }

        public List<Employee> Employees { get; set; }

    }
}