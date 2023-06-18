using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LabourManagementApp.Models
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is bool)
            {
                return (bool)value;
            }
            return false;
        }
    }
}