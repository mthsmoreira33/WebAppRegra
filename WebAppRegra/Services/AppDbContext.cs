using Microsoft.EntityFrameworkCore;
using WebAppRegra.Models;

namespace WebAppRegra.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ContactsModel> Contacts { get; set; }
        public DbSet<PhoneNumbersModel> PhoneNumbers { get; set; }

    }
}
