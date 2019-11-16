using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.Entities
{
    [Table("ClientProject")]
    public class ClientProject
    {
        [Key,Column(Order =1)]
        public int ClientID { get; set; }

        [Key, Column(Order = 2)]
        public int ProjectID { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }
}