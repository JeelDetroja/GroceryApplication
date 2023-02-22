using Grocery.Models;
using Grocery.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Grocery.Controllers
{
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        #region variables
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        HttpClient client = new HttpClient();
        #endregion variables

        #region constructor
        public AccountController(IHttpClientFactory httpClientFactory, ILogger<AccountController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this.client = _httpClientFactory.CreateClient("grocery");
        }
        #endregion constructor

        #region Login
        [Route("~/")]
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDetails userDetail = new UserDetails();
                    var postTask = client.PostAsJsonAsync<LoginViewModel>(client.BaseAddress + "/login", model);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        userDetail = JsonConvert.DeserializeObject<UserDetails>(data);

                        if (userDetail != null)
                        {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Sid, userDetail.UserId.ToString(), ClaimValueTypes.Integer),
                                new Claim(ClaimTypes.Name, userDetail.UserName),
                                new Claim(ClaimTypes.Email, userDetail.UserEmail)
                            };

                            #region Manage User Roles
                            if (userDetail.UserType.ToLower() == "admin")
                            {
                                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                            }
                            else if (userDetail.UserType.ToLower() == "employee")
                            {
                                claims.Add(new Claim(ClaimTypes.Role, "Employee"));
                            }
                            else if (userDetail.UserType.ToLower() == "customer")
                            {
                                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                            }
                            #endregion Manage User Roles

                            var claimsIdentity = new ClaimsIdentity(
                                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            //// Set current principal
                            //var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                            //var claimsPrincipal = new ClaimsPrincipal(identity);
                            //Thread.CurrentPrincipal = claimsPrincipal;

                            await HttpContext.SignInAsync(
                                    CookieAuthenticationDefaults.AuthenticationScheme,
                                    new ClaimsPrincipal(claimsIdentity),
                                    new AuthenticationProperties
                                    {
                                        IsPersistent = true
                                    });

                            //uID = userDetail.UserId;
                            _logger.LogInformation("User {Email} logged in at {Time}.", userDetail.UserEmail, DateTime.UtcNow);

                            return RedirectToAction("index", "home");
                        }
                        return RedirectToAction("login", "account");
                    }

                    else if (result.StatusCode.ToString() == "NotFound")
                    {
                        ModelState.AddModelError("", "Invalid login attempt");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.StatusCode.ToString());
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }
        #endregion Login

        #region Logout
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/login").Result;
                if (responce.IsSuccessStatusCode)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    return RedirectToAction("login");
                }
                return View();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion Logout

        #region Profile
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult Profile()
        {
            User user = new User();

            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            //claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;
            //var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
            //       .Select(c => c.Value).SingleOrDefault();
            //var userId = ClaimsPrincipal.Current.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            //var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();  

            //var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;


            if (Convert.ToInt32(userId) != 0)
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/" + userId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(data);
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "User not found");
                }
                return View(user);
            }
            return RedirectToAction("Login");
        }
        #endregion Profile

        #region List of Employees
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult ListOfEmployee()
        {
            List<User> employee = new List<User>();
            HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/employee").Result;
            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<User>>(data);
                if (employee != null)
                {
                    return View(employee);
                }
            }
            return RedirectToAction("index", "home");
        }
        #endregion List of Employees

        #region SignUp
        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public IActionResult SignUp(SignUpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModel = new SignUp
                    {
                        UserName = model.UserName,
                        UserEmail = model.UserEmail,
                        UserMobileNo = model.UserMobileNo,
                        UserDob = model.UserDob,
                        UserPassword = model.UserPassword,
                        CreatedBy = 1,
                        UpdatedBy = 1,
                        isActivated = true
                    };
                    var puttask = client.PostAsJsonAsync<SignUp>(client.BaseAddress + "/user", userModel);
                    puttask.Wait();
                    var result = puttask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("login", "account");
                    }
                    else if (result.StatusCode.ToString() == "BadRequest")
                    {
                        ModelState.AddModelError("", "this email already exist! Enter Diffrent");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.StatusCode.ToString());
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }
        #endregion SignUp

        #region Create Employee
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployee(SignUpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModel = new SignUp
                    {
                        UserName = model.UserName,
                        UserEmail = model.UserEmail.ToString().ToLower(),
                        UserMobileNo = model.UserMobileNo,
                        UserDob = model.UserDob,
                        UserPassword = model.UserPassword,
                        CreatedBy = Convert.ToInt32(Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault())),
                        UpdatedBy = Convert.ToInt32(Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault())),
                        isActivated = true
                    };
                    var puttask = client.PostAsJsonAsync<SignUp>(client.BaseAddress + "/employee", userModel);
                    puttask.Wait();
                    var result = puttask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListOfEmployee", "account");
                    }
                    else if (result.StatusCode.ToString() == "BadRequest")
                    {
                        ModelState.AddModelError("", "this email already exist! Enter Diffrent");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.StatusCode.ToString());
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion Create Employee

        #region Delete Employee
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/employee/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListOfEmployee");
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "employee not found");
                }
                else
                {
                    ModelState.AddModelError("", "employee not deleted");
                }
                return RedirectToAction("ListOfEmployee");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion Delete Employee
    }
}
