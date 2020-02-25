using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackStageCore3.Models
{
    public class DbModel : DbContext
    {
        public DbSet<alltestitem> Alltestitem { set; get; }
    
     
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseMySQL(@"Server=localhost;database=testapp;uid=root;pwd=woshishui");
        public DbModel(DbContextOptions<DbModel> options) : base(options)
        {

        }
    }
}
