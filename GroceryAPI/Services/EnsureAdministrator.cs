using GroceryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UserRoleAPI.Services
{
    public class EnsureAdministrator : IHostedService
    {
        // We need to inject the IServiceProvider so we can create the scoped service, ApplicationDbContext
        private readonly IServiceProvider _serviceProvider;
        public EnsureAdministrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a new scope to retrieve scoped services
            using var scope = _serviceProvider.CreateScope();
            // Get the DbContext instance
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //Add Administrator if not found
            string adminLoginName = "Administrator@gmail.com";
            int adminId = await applicationDbContext.JdTblUser
                .AsNoTracking()
                .Where(a => a.UserEmail == adminLoginName.ToUpper())
                .Select(a => a.UserId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (adminId == 0)
            {
                var password = "P@ssw0rd";
                var adminUser = new User
                {
                    UserTypeId = 1,
                    UserName = "Jeel Detroja",
                    UserEmail = adminLoginName.ToLower(),
                    UserMobileNo = "7069821980",
                    UserPassword = password,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    IsActivated = true
                };

                applicationDbContext.JdTblUser.Add(adminUser);
                try
                {
                    applicationDbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new InvalidOperationException($"DbUpdateConcurrencyException occurred creating new admin user in EnsureAdminHostedService.cs.");
                }
                catch (DbUpdateException)
                {
                    throw new InvalidOperationException($"DbUpdateException occurred creating new admin user in EnsureAdminHostedService.cs.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
