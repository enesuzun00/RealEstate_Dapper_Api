using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        void CreateEmployee(CreateEmployeeDto createEmployeeDto);
        void DeleteEmployee(int id);
        void UpdateEmployee(UpdateEmloyeeDto updateEmloyeeDto);
        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
