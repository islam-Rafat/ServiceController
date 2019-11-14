using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Minimum Lenght 2 Characters")]
        public string Location { get; set; }

        public string Image { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Expected Period")]
        public double ExpectedPeriod { get; set; }
    }
}