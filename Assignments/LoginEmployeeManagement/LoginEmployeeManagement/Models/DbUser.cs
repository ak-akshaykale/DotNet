using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginEmployeeManagement.Models
{
    public class DbUser
    {
        [Key]
        [DisplayName("User Name")]
        [Required(ErrorMessage = "UserId should not be Empty")]
        public string Uid { set; get; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password should not be Empty")]
        public string Pass { set; get; }

        [DisplayName("Re-enter Password")]
        [DataType(DataType.Password)]
        [Compare("Pass",ErrorMessage ="Passwords are not Same")]
        public string RePass { set; get; }

        [Required(ErrorMessage ="Full Name should not be Empty")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "EmailID should not be Empty")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { set; get; }

        [Required(ErrorMessage = "Mobile number should not be Empty")]
        [DataType(DataType.PhoneNumber)]
        public long Mobileno{ set; get; }
        public bool Remember { set; get; }
    }
}