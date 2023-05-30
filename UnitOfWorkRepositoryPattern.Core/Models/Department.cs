using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepositoryPattern.Core.Models
{
    public class Department : IEntity
    {
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
