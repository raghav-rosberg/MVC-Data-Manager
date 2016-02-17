using System.Collections.Generic;

namespace MvcUserManagement.data.EmployeeRespository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void InsertEmployee(Employee employee);
    }
}
