using AutoMapper;
using MVCDbFirst.Dtos;
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
        private readonly CompanyContext _context;

        public EmployeesController()
        {
            _context = new CompanyContext();
        }

        public IHttpActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees.Select(Mapper.Map<Employee, EmployeeDto>));
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _context
                .Employees
                .SingleOrDefault(e => e.ID == id);

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
            _context.Employees.Add(employee);
            _context.SaveChanges();
            employeeDto.ID = employee.ID;

            return Created(new Uri(Request.RequestUri + "/" + employee.ID), employeeDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employeeInDb = _context.Employees.SingleOrDefault(e => e.ID == id);
            if (employeeInDb == null)
                return NotFound();

            Mapper.Map(employeeDto, employeeInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeIdDb = _context.Employees.SingleOrDefault(e => e.ID == id);

            if (employeeIdDb == null)
                return NotFound();

            _context.Employees.Remove(employeeIdDb);
            _context.SaveChanges();

            return Ok(employeeIdDb);
        }

    }
}
