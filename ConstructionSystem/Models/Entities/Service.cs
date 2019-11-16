using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("Service")]
    public class Service
    {
        [Key]
        [Required]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Payment { get; set; }

    }
}