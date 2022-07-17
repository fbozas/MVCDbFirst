using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDbFirst.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyContext _context;
        public EmployeeRepository()
        {
            _context = new CompanyContext();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Employee employee = _context.Employees.Find(id);
            return employee;
        }

        public void Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
           if(id == null)
           {
                throw new ArgumentNullException(nameof(id));
           }

            Employee employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}