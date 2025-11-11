using EnercheckAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnercheckAPI.Data
{
    public class ApiDbContext : IdentityDbContext<Usuario>
    {

        public DbSet<Plano> Planos { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }



    }
}
