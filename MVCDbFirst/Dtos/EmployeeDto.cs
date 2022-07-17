using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDbFirst.Dtos
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Depid { get; set; }
        public double? Salary { get; set; }
        public DateTime? Hiredate { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}