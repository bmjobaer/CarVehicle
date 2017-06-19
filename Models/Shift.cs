using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarVehicle.Models
{
    public class Shift
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Shift Name")]
        public string ShiftName { get; set; }
        public virtual ICollection<SheduleVehicle> SheduleVehicles { get; set; }
    }
}