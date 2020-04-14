using Laba4_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApp
{
    class DataBaseContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }

        private readonly string _dataBasePath;

        public DataBaseContext(string dataBasePath)
        {
            _dataBasePath = dataBasePath;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dataBasePath}");
        }
    }
}
