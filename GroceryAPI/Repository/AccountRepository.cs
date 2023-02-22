using GroceryAPI.Entities;
using GroceryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Privet Filds
        private readonly AppDbContext _context;
        #endregion Privet Filds

        #region Constructor
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region AddUser
        public void AddUser(UserForCreationDto model)
        {
            var newUser = new User
            {
                UserTypeId = 6,
                UserName = model.UserName,
                UserEmail = model.UserEmail.ToLower(),
                UserPassword = model.UserPassword,
                UserMobileNo = model.UserMobileNo,
                UserDob = model.UserDob,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                IsActivated = model.isActivated
            };

            _context.JdTblUser.Add(newUser);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("Database Exception occurred creating a new user.");
            }
        }
        #endregion AddUser

        #region AuthenticateUser
        public async Task<User> AuthenticateUser(LoginDto model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return null;

            var user = await _context.JdTblUser
                .AsNoTracking().Include(e => e.UserType)
                .Where(a => a.UserEmail.ToLower() == model.Email.ToLower())
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (user == null)
                return null;

            if (model.Password != user.UserPassword)
                return null;

            return user;
        }
        #endregion AuthenticateUser

        #region Get User by email
        public int GetUserByEmail(string email)
        {
            return _context.JdTblUser.Where(e => e.UserEmail == email).Count();
        }
        #endregion Get User by email

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        #region Get User
        public async Task<User> GetUser(int userId)
        {
            return await _context.JdTblUser.Include(e => e.UserType).Where(e => e.IsActivated && e.UserId == userId).FirstOrDefaultAsync();
        }
        #endregion Get User

        #region Get Employees
        public async Task<List<User>> GetEmployees()
        {
            return await _context.JdTblUser.Include(e => e.UserType).Where(e => e.IsActivated && e.UserTypeId == 4).ToListAsync();
        }
        #endregion Get Employees

        #region Add Employee
        public void AddEmployee(UserForCreationDto model)
        {
            var newUser = new User
            {
                UserTypeId = 4,
                UserName = model.UserName,
                UserEmail = model.UserEmail.ToLower(),
                UserPassword = model.UserPassword,
                UserMobileNo = model.UserMobileNo,
                UserDob = model.UserDob,
                CreatedBy = 1,
                UpdatedBy = 1,
                IsActivated = true
            };

            _context.JdTblUser.Add(newUser);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("Database Exception occurred creating a new user.");
            }
        }
        #endregion Add Employee

        #region Delete Employee
        public void DeleteEmployee(User user)
        {
            _context.JdTblUser.Remove(user);
        }
        #endregion Delete Employee

        #region Save
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        #endregion Save

    }
}
