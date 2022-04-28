using Delete.Models;
using Microsoft.EntityFrameworkCore;

namespace Delete.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }
    }
}
