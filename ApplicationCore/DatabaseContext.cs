using DomainsModel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public class DatabaseContext:IdentityDbContext<User,Role,int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<User> AspNetUsers { get; set; }
        public DbSet<Role> AspNetRoles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            if (!optionsBuilder.IsConfigured)
             {
                 optionsBuilder.UseSqlServer(@"data source=LAPTOP-6RBKI73J\SQLEXPRESS; initial catalog=TeamingUp;persist security info=True;user id=sa;password=SqlServerPassLocalEnvironment;");
             }
         }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityUserRole<int>>(i =>
            {
                i.HasKey(x => new { x.RoleId, x.UserId });
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(i =>
            {
                i.HasIndex(x => new { x.ProviderKey, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(i=>{
                i.HasKey(x => x.Id);
            });
            modelBuilder.Entity<IdentityUserClaim<int>>(i =>
            {
                i.HasKey(x => x.UserId);
            });
            modelBuilder.Entity<IdentityUserToken<int>>(i =>
            {
                i.HasKey(x => x.UserId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
