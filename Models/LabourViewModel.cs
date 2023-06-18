using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabourManagementApp.Models
{
    [Table("Labours Detail")]
    public class LabourViewModel
    {
        [Key]
        public int Lid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name not to be emplty")]
        public string Fname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name not to be emplty")]
        public string Lname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "must be select Gender")]
        public string Gender { get; set; }
        [Range(18, 40, ErrorMessage = "Age must be between 18 to 40")]
        public int Age { get; set; }
        public string Bg { get; set; }
        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone number must be 10 digits..")]
        public long Number { set; get; }
        [CheckBoxRequired(ErrorMessage ="Please accept the terms and condion.")]
        public bool IsPolicyAccepted { set; get; }

        public List<Gender> Genders
        {
            get
            {
                LabourModelManager labourModel = new LabourModelManager();
                List<Gender> gs = labourModel.GetGender();
                return gs;
            }
        }

        public IEnumerable<SelectListItem> Bgs
        {
            get
            {
                LabourModelManager labourModel = new LabourModelManager();
                List<Bg> bgs = labourModel.Getbgs();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (var item in bgs)
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Value = item.name;
                    selectListItem.Text = item.name;
                    selectListItem.Selected = item.name == "a+ve" ? true : false;
                    selectListItems.Add(selectListItem);
                }
                return selectListItems;
            } 
        }
    }
}