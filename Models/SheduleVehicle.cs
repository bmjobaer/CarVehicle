using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarVehicle.Models
{
    public class SheduleVehicle
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required, Display(Name="Select Vehicle")]
        public int SelectVehicle { get; set; }
        [ForeignKey("SelectVehicle")]
        public virtual SaveVehicle SaveVehicles { get; set; }



        [Required,Display(Name="Select Date")]
        [DataType(DataType.Date)]
        public DateTime SelectDate { get; set; }


        [Required,Display(Name="Select Shift")]
        public int SelectShift { get; set; }
        [ForeignKey("SelectShift")]
        public virtual Shift Shift { get; set; }


        [Required, Display(Name = "Book By")]
        public string BookedBy { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}