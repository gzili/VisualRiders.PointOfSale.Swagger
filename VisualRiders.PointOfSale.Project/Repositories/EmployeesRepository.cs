using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class EmployeesRepository
    {
        private static readonly List<Employee> _employees = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Email = Guid.NewGuid().ToString().Substring(0, 5) + "@" + Guid.NewGuid().ToString().Substring(0, 5) + "." + Guid.NewGuid().ToString().Substring(0, 3),
                Name = "Antanas",
                Password = "Antanas123",
                Status = EmployeeStatus.Active
            },
            new()
            {
                Id = Guid.NewGuid(),
                Email = Guid.NewGuid().ToString().Substring(0, 5) + "@" + Guid.NewGuid().ToString().Substring(0, 5) + "." + Guid.NewGuid().ToString().Substring(0, 3),
                Name = "Petras",
                Password = "Petras123",
                Status = EmployeeStatus.Active
            }
        };

        public void Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            _employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(Guid id) => _employees.Find(p => p.Id == id);

        public void Update(Employee employee)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (employee.Id != _employees[i].Id) continue;
                _employees[i] = employee;
            }
        }

        public bool Delete(Employee employee)
        {
            return _employees.RemoveAll(a => a.Id == employee.Id) > 0;
        }
    }
}
