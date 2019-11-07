using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Asp.net_Approach.Models
{
    public class DeptModel
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
    }
}