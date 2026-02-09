using Microsoft.EntityFrameworkCore;
using VehicleWebAPICRUD.Data;

namespace VehicleWebAPICRUD.VehicleDBContext
{
    public class db_context : DbContext
    {
        private readonly IConfiguration _configuration;
        public db_context(IConfiguration configuration)
        {
            _configuration = configuration;

        }
       
        
        public DbSet<vehicle> vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var data_string = _configuration.GetConnectionString("MySqlConn");

            optionsBuilder.UseSqlServer(data_string);
        }

    }
   
}
