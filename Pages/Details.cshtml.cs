using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MicroBlog.Models;
using MicroBlog.Services;

namespace MicroBlog.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly PostService postService;

        public Post? Post { get; set; }

        public DetailsModel(PostService postService)
        {
            this.postService = postService;
        }
        public IActionResult OnGet(int id)
        {
            Post = postService.GetPost(id);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
