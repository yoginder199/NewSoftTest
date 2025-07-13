using neosoftCrudApis.Models;
using System.Collections.Generic;
using System.Linq;

namespace neosoftCrudApis.Services
{
    public class EmployeeService
    {
        private static List<Employee> _employees = new List<Employee>();
        private static int _nextId = 1;

        public List<Employee> GetAll() => _employees;

        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public Employee Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
            return employee;
        }

        public bool Update(int id, Employee updated)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return false;

            existing.FullName = updated.FullName;
            existing.Department = updated.Department;
            existing.Salary = updated.Salary;
            return true;
        }

        public bool Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return false;

            _employees.Remove(employee);
            return true;
        }
    }
}
