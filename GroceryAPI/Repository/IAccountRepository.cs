using GroceryAPI.Entities;
using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public interface IAccountRepository
    {
        Task<User> AuthenticateUser(LoginDto model);
        int GetUserByEmail(string email);
        void AddEmployee(UserForCreationDto model);
        void AddUser(UserForCreationDto model);
        Task<List<User>> GetUsers();
        Task<List<User>> GetEmployees();
        Task<User> GetUser(int userId);
        void DeleteEmployee(User user);
        bool Save();
    }
}
