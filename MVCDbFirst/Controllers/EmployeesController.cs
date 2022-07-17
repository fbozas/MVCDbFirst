using AutoMapper;
using MVCDbFirst.Dtos;
using MVCDbFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCDbFirst.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public IHttpActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return Ok(employees.Select(Mapper.Map<Employee, EmployeeDto>));
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
               

            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);
            _employeeRepository.Create(employee);
            _employeeRepository.Save();
            employeeDto.ID = employee.ID;

            return Created(new Uri(Request.RequestUri + "/" + employee.ID), employeeDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employeeInDb = _employeeRepository.GetById(id);
            if (employeeInDb == null)
                return NotFound();

            Mapper.Map(employeeDto, employeeInDb);
            _employeeRepository.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeIdDb = _employeeRepository.GetById(id);

            if (employeeIdDb == null)
                return NotFound();

            _employeeRepository.Delete(id);
            _employeeRepository.Save();

            return Ok(employeeIdDb);
        }

    }
}
