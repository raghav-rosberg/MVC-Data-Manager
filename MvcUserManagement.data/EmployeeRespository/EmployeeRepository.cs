using System.Collections.Generic;
using MvcDataManager;

namespace MvcUserManagement.data.EmployeeRespository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeRepository()
        {
            _unitOfWork = new UnitOfWork(new MvcUserManagementDbContext());
            _employeeRepository = new RepositoryBase<Employee>(_unitOfWork);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public void InsertEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
            _unitOfWork.Commit();
        }
    }
}
