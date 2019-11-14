using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Employee
    {
        public int EmpID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name ="Employee Name")]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Space and numbers not allowed")]//space and numbers
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }

    }
}