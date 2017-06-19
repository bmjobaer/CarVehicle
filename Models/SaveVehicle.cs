using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarVehicle.Models
{
    public class SaveVehicle
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required, Display(Name="Reg. No")]
        public string RegNo { get; set; }


        [Required, Display(Name="Engine No")]
        public string EngineNo { get; set; }
        public virtual ICollection<SheduleVehicle> SheduleVehicles { get; set; }
    }
}