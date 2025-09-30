using Microsoft.EntityFrameworkCore;
using Barlangok.Models;

namespace Barlangok.Data
{
    public class BarlangokDbContext : DbContext
    {
        public BarlangokDbContext(DbContextOptions<BarlangokDbContext> options) : base(options)
        {

        }
        public DbSet<Barlangok.Models.BarlangokModel> Barlangok { get; set; }
    }
}
