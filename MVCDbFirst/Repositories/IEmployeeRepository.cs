using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDbFirst.Repositories
{
    interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int? id);

        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int? id);

    }
}
