using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_grams.Models.Interfaces
{
  public  interface IPost
    {

        //Find
        Task<Post> FindPostAsync(int id);


        //GetAll
        Task<List<Post>> GetPosts();
       

        //Delete
        Task DeleleAsync(int id);

        //Save
        Task SaveAsync(Post post);
    }
}
