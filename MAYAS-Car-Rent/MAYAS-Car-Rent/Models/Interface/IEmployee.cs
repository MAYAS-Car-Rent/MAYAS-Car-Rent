using MAYAS_Car_Rent.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Interface
{
    public interface IEmployee
    {
        Task<Employee> CreateEmployee(Employee employee);

        Task<List<EmployeeDTO>> GetEmployees(int companyId);

        Task<EmployeeDTO> GetEmployee(int id, int companyId);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);
    }
}