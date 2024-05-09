using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee newEmployee);
        Employee GetById(int employeeId);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int id);
        Task Delete(int employeeId);
        decimal UnionFees(int id);
        decimal StudentLoanRepamentAmount(int id, decimal totalAmount);
        IEnumerable<Employee> GetAll();
    }
}
