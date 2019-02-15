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
                    URL = "https://via.placeholder.com/200?text=DotNetGram"

                },
                new Post
                {
                    ID = 2,
                    Description = "beach view",
                    PosterName = "xxl",
                    URL = "https://via.placeholder.com/200?text=DotNetGram"

                },
                new Post
                {
                    ID=3,
                    Description = "cute kitty",
                    PosterName = "xxxl",
                    URL = "https://via.placeholder.com/200?text=DotNetGram"
                },
                new Post
                {
                    ID=4,
                    Description="winter time",
                    PosterName="xxxl",
                    URL = "https://via.placeholder.com/200?text=DotNetGram"
                },
                new Post
                {
                    ID = 5,
                    Description = "happy hour",
                    PosterName = "xxxl",
                    URL = "https://via.placeholder.com/200?text=DotNetGram"

                }


                );
        }




        public DbSet<Post> Posts { get; set; }


    }
}
