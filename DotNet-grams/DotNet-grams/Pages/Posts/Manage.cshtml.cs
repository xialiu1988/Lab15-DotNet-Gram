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
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        public ManageModel(IPost post)
        {
            _post = post;
        }

        public async Task OnGet()
        {

            Post = await _post.FindPostAsync(ID.GetValueOrDefault())?? new Post();

        }

        public async Task<IActionResult> OnPost()
        {
         var rest=   await _post.FindPostAsync(ID.GetValueOrDefault()) ?? new Post();

            rest.PosterName = Post.PosterName;
            rest.Description = Post.Description;
            rest.URL = Post.URL;


            await _post.SaveAsync(rest);
            return RedirectToPage("/Posts/Index", new { id=rest.ID });
        }


        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleleAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}