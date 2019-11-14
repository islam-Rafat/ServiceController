using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("EmployeeProject")]
    public class EmployeeProject
    {
        [Key, Column(Order = 1)]
        [Required]
        public int EmployeeId { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        public int ProjectId { get; set; }

        [Display(Name = "Working Hours")]
        public double Hours { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }


    }
}