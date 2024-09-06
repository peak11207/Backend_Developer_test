using Backend_Developer_test.DATA;
using Backend_Developer_test.DTOs;
using Backend_Developer_test.Models;
using AutoMapper;
using System;
using Backend_Developer_test.Repositories;

namespace Backend_Developer_test.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDTO employeeDto);
        Task UpdateEmployeeAsync(EmployeeDTO employeeDto);
        Task DeleteEmployeeAsync(int id);
    }

    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
