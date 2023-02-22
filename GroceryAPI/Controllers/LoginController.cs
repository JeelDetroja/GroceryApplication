using AutoMapper;
using GroceryAPI.Entities;
using GroceryAPI.Models;
using GroceryAPI.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroceryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        #region privet field
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        #endregion privet field

        #region constructor
        public LoginController(AppDbContext context, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
        }
        #endregion constructor

        #region logout
        [HttpGet(Name = "Logout")]
        public ActionResult Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
        #endregion logout

        #region login
        [HttpPost(Name = "Login")]
        public async Task<ActionResult> Login(LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await _accountRepository.AuthenticateUser(model);
                    if (user == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Invalid login attempt");
                    }

                    //#region manage claims
                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString(), ClaimValueTypes.Integer),
                    //    new Claim(ClaimTypes.Name, user.UserName),
                    //    new Claim(ClaimTypes.Email, user.UserEmail)

                    //};

                    //#region Manage User Roles
                    //if (user.UserType.UserType.ToLower() == "admin")
                    //{
                    //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    //}
                    //else if (user.UserType.UserType.ToLower() == "employee")
                    //{
                    //    claims.Add(new Claim(ClaimTypes.Role, "Employee"));
                    //}
                    //else if (user.UserType.UserType.ToLower() == "customer")
                    //{
                    //    claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                    //}
                    //#endregion Manage User Roles

                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //#endregion manage claims

                    //await HttpContext.SignInAsync(
                    //    CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity),
                    //    new AuthenticationProperties
                    //    {
                    //        IsPersistent = true
                    //    });

                    UserViewDto userDetail = new UserViewDto
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        UserEmail = user.UserEmail,
                        UserType = user.UserType.UserType
                    };
                    return Ok(userDetail);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
        #endregion login
    }
}
