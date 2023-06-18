using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabourManagementApp.Models
{
    public class Labour
    {
        public int Lid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="FName not to be emplty")]
        public string Fname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "LName not to be emplty")]
        public string Lname { get; set; }
        [Range(18, 40, ErrorMessage = "Age must be between 18 to 40")]
        public int Age { get; set; }
        public string Bg { get; set; }
        public long Number { set; get; }
    }
}