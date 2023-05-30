using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepositoryPattern.Core.Models
{
    public class Employee :  IEntity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfHiring { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
