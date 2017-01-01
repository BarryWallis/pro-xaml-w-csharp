using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Domain.Entities
{
    public class Employee
    {
        public enum RoleType
        {
            GeneralEmployee,
            TeamLeader,
            Supervisor,
        }

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleType Role { get; set; }

        /// <summary>
        /// Create a new Employee with the given Id.
        /// </summary>
        /// <param name="id">The employee's id.</param>
        public Employee(int id)
        {
            Id = id;
        }
    }
}
