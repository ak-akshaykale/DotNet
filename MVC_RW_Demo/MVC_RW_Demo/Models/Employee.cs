using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RW_Demo.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { set; get; }
        public string Name { set; get; }
        public int DeptNo{ set; get; }
        public decimal Basic { set; get; }
    }
}