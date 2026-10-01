using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MicroBlog.Models;
using MicroBlog.Repositories;

namespace MicroBlog.Pages;

public class IndexModel : PageModel
{
    private readonly IBlogRepository blogRepository;

    public List<Post> Posts { get; set; } = new();

    public IndexModel(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    public void OnGet()
    {
        Posts = blogRepository.GetAll().ToList();
    }
}
