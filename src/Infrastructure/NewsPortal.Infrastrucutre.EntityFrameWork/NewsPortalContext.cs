using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain;

namespace NewsPortal.Infrastrucutre.EntityFrameWork
{
    public class NewsPortalContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Comments> Comments { get; set; }


        public NewsPortalContext(DbContextOptions<NewsPortalContext> options)
                   : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comments>(entity =>
            {

                entity.HasKey(e => e.CommentId);
            });
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NewsID");
            });

        }
   

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
        //}
    }

}

