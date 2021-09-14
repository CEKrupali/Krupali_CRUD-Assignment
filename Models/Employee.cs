using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Krupali_CRUD_Assignment.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public List<EmployeeDetial> EmployeeDtlList { get; set; }
    }
    public class EmployeeDetial
    {
        public int EmpDtlId { get; set; }
        public int EmpId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}