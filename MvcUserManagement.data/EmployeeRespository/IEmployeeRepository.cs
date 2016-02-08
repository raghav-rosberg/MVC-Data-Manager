using System.Collections.Generic;
using MvcDataManager;

namespace MvcUserManagement.data.EmployeeRespository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void InsertEmployee(Employee employee);
    }
}
