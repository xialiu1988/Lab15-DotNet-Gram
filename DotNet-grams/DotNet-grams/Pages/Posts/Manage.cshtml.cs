using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNet_grams.Models;
using DotNet_grams.Models.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DotNet_grams.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Models.Util.Blob BlobImage { get; set; }

        public ManageModel(IPost post,IConfiguration configuration)
        {
            _post = post;

            //Blob storage account to be referenced
            BlobImage = new Models.Util.Blob(configuration);
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

            //uploading image
            if (Image != null)
            {
                var filePath = Path.GetTempFileName();
                using(var stream=new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //get container
                var container = await BlobImage.GetContainer("postimages");

                //upload the image
             BlobImage.UploadFile(container, Image.FileName, filePath);

           CloudBlob blob= await BlobImage.GetBlob(Image.FileName, container.Name);
                rest.URL = blob.Uri.ToString();
            }

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