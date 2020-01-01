using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RW_Demo.Models
{
    public class DbUser
    {
        [Key]
        [DisplayName("User Name")]
        public string Uid { set; get; }
        [DisplayName("Password")]
        public string Pass { set; get; }
        public bool Remember { set; get; }
    }
}