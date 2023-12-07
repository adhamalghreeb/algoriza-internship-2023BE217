

namespace Ve2
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { 

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VezeetaDB");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users") // Base class table
                .HasDiscriminator<UserType>("UserType")
                .HasValue<User>(UserType.RegularUser)
                .HasValue<Doctor>(UserType.Doctor)
                .HasValue<Patient>(UserType.Patient);

            modelBuilder.Entity<Doctor>()
                .ToTable("Users") // Use the same table as the base class
                .HasBaseType<User>()
                .HasOne(d => d.SpecialtyNavigation)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .IsRequired(false);


            modelBuilder.Entity<Patient>()
                .ToTable("Users") // Use the same table as the base class
                .HasBaseType<User>();

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });


        }
    }
}
