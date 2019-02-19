using DotNet_grams.Data;
using DotNet_grams.Models;
using DotNet_grams.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace gramTDD
{
   public class PostTDD
    {
        /// <summary>
        /// can create post
        /// </summary>
        [Fact]
        public async void cancreatePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreatePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                post.PosterName = "tester";
                post.URL = "test.jpg";
                post.Description = "this is a test post";

                PostManager service = new PostManager(context);
                await service.SaveAsync(post);
                Post result = await context.Posts.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal(post, result);
            }

        }


        /// <summary>
        /// get one post
        /// </summary>
        [Fact]
        public async void CanReadSinglePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("GetAPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager service = new PostManager(context);
                Post post = new Post();
                post.ID = 1;
                post.PosterName = "tester";
                post.URL = "test.jpg";
                post.Description = "this is a test post";
                await service.SaveAsync(post);

                Post result = await service.FindPostAsync(post.ID);

                Assert.Equal(post, result);
            }
        }


        /// <summary>
        /// edit test
        /// </summary>
        [Fact]
        public async void CanEditPost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("EditPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager service = new PostManager(context);
                Post post = new Post();
                post.ID = 1;
                post.PosterName = "tester";
                post.URL = "test.jpg";
                post.Description = "this is a test post";
                await service.SaveAsync(post);


                Post newpost = new Post();
                newpost.PosterName = "Poster";
                post.PosterName = newpost.PosterName;
                await service.SaveAsync(post);
                Post result = await context.Posts.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal("Poster", result.PosterName);
            }
        }

        /// <summary>
        /// test delete
        /// </summary>
        [Fact]
        public async void CanDeletePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("DeletePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager service = new PostManager(context);
                Post p1 = new Post();
                p1.ID = 1;
                p1.PosterName = "alley";
                p1.Description = "ts1";
                p1.URL = "ts.jpg";
                await service.SaveAsync(p1);

                Post p2 = new Post();
                p2.ID = 2;
                p2.PosterName = "blob";
                p2.Description = "ts2";
                p2.URL = "ts2.jpg";
                await service.SaveAsync(p2);


                await service.DeleleAsync(p1.ID);
                var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == p1.ID);

                Assert.Null(result);
            }
        }




    }
}
