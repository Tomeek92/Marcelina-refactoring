﻿using Marcelina_Domain.Szkolenia;
using Marcelina_Domain.Users;
using Marcelina_Domain.Uslugi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marcelina_infrastructure.DbContext
{
    public class MarcelinaRefactoringDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Szkolenie> Szkolenia { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
    }
}