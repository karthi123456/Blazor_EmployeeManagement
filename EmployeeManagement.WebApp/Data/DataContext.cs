using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.WebApp.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {

        }
    }
}
