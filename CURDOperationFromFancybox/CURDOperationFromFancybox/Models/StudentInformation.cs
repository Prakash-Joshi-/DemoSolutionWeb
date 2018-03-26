using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CURDOperationFromFancybox.Models
{
    public class StudentInformation
    {
        [Key]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Course")]
        public string Course { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
    }
}