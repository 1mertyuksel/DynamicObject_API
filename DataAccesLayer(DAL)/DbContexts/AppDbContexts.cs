using EntityLayer.Config.Concrete;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccesLayer_DAL_.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<EntityLayer.Models.Concrete.DynamicObject> DynamicObjects { get; set; }

        public DbSet<DynamicField> DynamicFields { get; set; }  
        public DbSet<TransactionLog> TransactionLogs { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(@"Server=localhost;Database=DynamicObjectAPI;Uid=root;password=Password187");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DynamicFieldConfig());
            modelBuilder.ApplyConfiguration(new TransactionLogConfig());
            modelBuilder.ApplyConfiguration(new DynamicObjectConfig());
        }
    }
}