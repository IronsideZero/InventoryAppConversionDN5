namespace InventoryAppConversion.DataAccess
{
    using global::Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this says that a User entity has one Role entity as a a part of it
            modelBuilder.Entity<User>()
                .HasOne<Role>(u => u.Role);

            modelBuilder.Entity<User>()
                .HasOne<Company>(u => u.Company);

            //this says that a Category has a collection of Item entities as a part of it
            modelBuilder.Entity<Category>()
                .HasMany<Item>(ca => ca.ItemList);

            modelBuilder.Entity<Role>()
                .HasMany<User>(r => r.UserList);

            modelBuilder.Entity<Company>()
                .HasMany<User>(co => co.UserList);

            modelBuilder.Entity<Item>()
                .HasOne<Category>(i => i.Category);

            modelBuilder.Entity<Item>()
                .HasOne<User>(i => i.Owner);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
