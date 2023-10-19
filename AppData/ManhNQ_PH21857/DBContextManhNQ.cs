using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
namespace AppData.ManhNQ_PH21857
{
    public class DBContextManhNQ : DbContext
    {
        public DBContextManhNQ()
        {

        }

        public DBContextManhNQ(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<SinhVien> sinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=HẢI\\SQLEXPRESS;Initial Catalog=thithu; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
