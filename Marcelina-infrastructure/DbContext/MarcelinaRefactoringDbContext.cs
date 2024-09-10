using Marcelina_Domain.Enties.Szkolenia;
using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Uslugi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marcelina_infrastructure.DbContext
{
    public class MarcelinaRefactoringDbContext : IdentityDbContext<User>
    {
        public MarcelinaRefactoringDbContext(DbContextOptions<MarcelinaRefactoringDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Szkolenie> Szkolenia { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
    }
}