using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MicroBlog.Models;
using MicroBlog.Repositories;

namespace MicroBlog.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IBlogRepository blogRepository;

        public CreateModel(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        [BindProperty]
        public Post Post { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            blogRepository.Add(Post);
            blogRepository.Save();

            return RedirectToPage("/Index");
        }
    }
}
