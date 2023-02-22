using GroceryAPI.Entities;
using GroceryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region privet filds
        private readonly IAccountRepository _accountRepository;
        #endregion privet filds

        #region constructor
        public EmployeeController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        #endregion constructor

        #region get employee list
        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var employees = await _accountRepository.GetEmployees();
                if (employees != null)
                {
                    var result = employees.Select(x => new UserDto(x)).ToList();
                    //var result = new UserDto(employees);
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                string m = ex.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion get product by id

        #region Create New Employee
        [HttpPost(Name = "CreateEmployee")]
        public ActionResult CreateEmployee(UserForCreationDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model == null)
                    {
                        return BadRequest();
                    }
                    int count = _accountRepository.GetUserByEmail(model.UserEmail);
                    if (count == 0)
                    {
                        _accountRepository.AddEmployee(model);
                        return Ok();
                    }
                    else
                    {
                        ModelState.AddModelError("UserEmail", "User already exist ! please login with diffrent name and email");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception e)
            {
                string m = e.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion Create New Employee

        #region Delete Employee
        [HttpDelete("{userId}", Name = "DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int userId)
        {
            try
            {
                var employeeFromRepo = await _accountRepository.GetUser(userId);

                if (employeeFromRepo == null)
                {
                    return NotFound();
                }

                _accountRepository.DeleteEmployee(employeeFromRepo);
                _accountRepository.Save();

                return Ok();
            }
            catch (Exception e)
            {
                string m = e.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }

        }
        #endregion Delete Employee
    }
}
