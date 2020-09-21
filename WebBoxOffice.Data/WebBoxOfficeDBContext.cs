using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Data
{
    /// <summary>
    /// WebBoxOfficeDBContext - default db context
    /// </summary>
    public class WebBoxOfficeDbContext: DbContext
    {
       

        /// <summary>
        /// BoxOffices
        /// </summary>
        public DbSet<DataBoxOffice> BoxOffices { get; set; }

        /// <summary>
        /// Customers
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// CustomerTickets
        /// </summary>
        public DbSet<CustomerTickets> CustomerTickets { get; set; }

        /// <summary>
        /// Halls
        /// </summary>
        public DbSet<Hall> Halls { get; set; }
        /// <summary>
        /// Schedules
        /// </summary>
        public DbSet<Schedule> Schedules { get; set; }
        /// <summary>
        /// Spectacles
        /// </summary>
        public DbSet<Spectacle> Spectacles { get; set; }

        /// <summary>
        /// SpectaclesLinks
        /// </summary>
        public DbSet<SpectaclesLinks> SpectaclesLinks { get; set; }
        /// <summary>
        /// Tickets
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }

        
        /// <summary>
        /// ctor
        /// </summary>
        public WebBoxOfficeDbContext(DbContextOptions<WebBoxOfficeDbContext> options):base(options)
        {
            
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataBoxOffice>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<DataBoxOffice>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            


            modelBuilder.Entity<Customer>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");

            modelBuilder.Entity<CustomerTickets>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CustomerTickets>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            modelBuilder.Entity<CustomerTickets>()
                .HasOne(o => o.Customer)
                .WithMany(m => m.Tickets)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<Hall>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Hall>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            modelBuilder.Entity<Hall>()
                .HasOne(p => p.DataBoxOffice)
                .WithMany(b => b.Halls)
                .HasForeignKey(k=>k.DataBoxOfficeId);
            

            modelBuilder.Entity<Schedule>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Schedule>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            modelBuilder.Entity<Schedule>()
                .HasOne(p => p.Hall)
                .WithMany(b => b.Schedules)
                .HasForeignKey(k => k.HallId);
            modelBuilder.Entity<Schedule>()
                .HasOne(p => p.Spectacle)
                .WithMany(b => b.Schedules)
                .HasForeignKey(k => k.SpectacleId);



            modelBuilder.Entity<Spectacle>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Spectacle>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            


            modelBuilder.Entity<SpectaclesLinks>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SpectaclesLinks>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            modelBuilder.Entity<SpectaclesLinks>()
                .HasOne(p => p.Spectacle)
                .WithMany(b => b.SpectacleLinks)
                .HasForeignKey(k => k.SpectacleId);

            modelBuilder.Entity<Ticket>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Ticket>().Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GetUtcDate()");
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Schedule)
                .WithMany(b => b.Tickets)
                .HasForeignKey(k => k.ScheduleId);
            


        }
    }
}
