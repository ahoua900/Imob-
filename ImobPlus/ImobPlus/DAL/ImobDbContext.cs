using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ImobPlus.Models;
using System.Linq;
using System.Web;

namespace ImobPlus.DAL
{
    public class ImobDbContext : DbContext 
    {
        public DbSet<Construire> Construires { get; set; }
        public DbSet<Demenagement> Demenagements { get; set; }
        public DbSet<Investir> Investirs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<ContactPro>  ContactPros { get; set; }
        
        public DbSet<Liconseil> Liconseils { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1MOS7C0;Initial Catalog=ImobDatabase;Integrated Security=True"));
        }

       
    }
}