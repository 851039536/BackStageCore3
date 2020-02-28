using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackStageCore3.Models
{
    public class DbModel : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<alltestitem> alltestitem { set; get; }
        public DbSet<testitem> testitem { set; get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseMySQL(@"Server=localhost;database=testapp;uid=root;pwd=woshishui");
        public DbModel(DbContextOptions<DbModel> options) : base(options)
        {

        }
    }
}
