using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("ProjectService")]
    public class ProjectService
    {
        [Key,Column(Order =1)]
        public int ProjectID { get; set; }

        [Key, Column(Order = 2)]
        public int ServiceID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        [ForeignKey("ServiceID")]
        public Service Service { get; set; }
    }
}