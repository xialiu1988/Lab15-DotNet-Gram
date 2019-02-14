using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_grams.Models;
using DotNet_grams.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNet_grams.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPost _post;

        public IndexModel(IPost post)
        {
            _post = post;
        }

        [FromRoute]
        public int ID { get; set; }

        public Post Post { get; set; }

        public async Task OnGet()
        {

            //set all the data for my  .cshtml page

            //get the specific post data for the id  that was sent
            Post = await _post.FindPostAsync(ID);
        }
    }
}