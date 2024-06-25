using Microsoft.EntityFrameworkCore;
using Reports.DAL.Messages;
using Reports.DAL.Reports;
using Reports.DAL.Stuff.Directors;
using Reports.DAL.Stuff.Employees;

namespace Reports.DAL.Contexts;

public sealed class ReportsAppContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Director> Directors { get; set; }

    public ReportsAppContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public ReportsAppContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ReportsAppDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(builder =>
        {
            builder.OwnsOne(x => x.MessageInfo);
            builder.OwnsOne(x => x.MessageSender);
        });

        modelBuilder.Entity<Report>(builder =>
        {
            builder.OwnsOne(x => x.ReportInfo);
            builder.OwnsOne(x => x.ReportMessageList).OwnsOne(x => x.Messages);
        });

        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.EmployeeAccount);
        });

        modelBuilder.Entity<Director>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.DirectorAccount);
        });
    }
}