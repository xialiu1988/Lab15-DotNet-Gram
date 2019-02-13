using DotNet_grams.Data;
using DotNet_grams.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_grams.Models.Services
{
    public class PostManager : IPost
    {
        private readonly PostDbContext _context;

        public PostManager(PostDbContext context)
        {
            _context = context;
        }


        public async Task DeleleAsync(int id)
        {
           Post post= await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> FindPostAsync(int id)
        {
          Post post= await _context.Posts.FirstOrDefaultAsync(p=>p.ID==id);

           return post;
        }

        public async Task<List<Post>> GetPosts()
        {
           return await _context.Posts.ToListAsync();
        }

        public async Task SaveAsync(Post post)
        {
            //create new post or update one
            //if it does not exsit in DB CREATE ONE 
            Post res = await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);

            if (res == null)
            {
                _context.Posts.Add(post);

            }
            else
            {  //update it if it exsits
                res = post;
                _context.Posts.Update(res);
            }
            await _context.SaveChangesAsync();
            
        }
    }
}
