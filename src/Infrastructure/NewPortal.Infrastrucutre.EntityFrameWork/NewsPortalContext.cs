using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain;

namespace NewPortal.Infrastrucutre.EntityFrameWork
{
    public class NewsPortalContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comment { get; set; }


        public NewsPortalContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
        }
    }

}

