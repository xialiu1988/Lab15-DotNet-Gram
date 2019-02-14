using DotNet_grams.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_grams.Data
{
    public class PostDbContext:DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options):base
            (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                { ID = 1,
                    Description = "beach view",
                    PosterName = "xl",
                    URL = "beachview.jpg"

                },
                new Post
                {
                    ID = 2,
                    Description = "beach view",
                    PosterName = "xxl",
                    URL = "beachview.jpg"

                },
                new Post
                {
                    ID=3,
                    Description = "cute kitty",
                    PosterName = "xxxl",
                    URL = "cute.jpg"
                },
                new Post
                {
                    ID=4,
                    Description="winter time",
                    PosterName="xxxl",
                    URL="wintertime.jpg"
                },
                new Post
                {
                    ID = 5,
                    Description = "happy hour",
                    PosterName = "xxxl",
                    URL = "happyhour.jpg"

                }


                );
        }




        public DbSet<Post> Posts { get; set; }


    }
}
