﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepositoryPattern.Core.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public DateTime DateOfHiring { get; set; } = DateTime.Now;
        [Required]
        public int DepartmentId { get; set; }
    }
}
