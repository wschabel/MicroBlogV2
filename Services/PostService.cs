using MicroBlog.Models;
using System.Text.Json;

namespace MicroBlog.Services
{
    public class PostService
    {
        private List<Post> posts = new();

        private readonly string filePath;

        public PostService(IWebHostEnvironment environment)
        {
            filePath = Path.Combine(
                environment.ContentRootPath,
                "data",
                "posts.json"
            );

            LoadPosts();
        }

        private void LoadPosts()
        {
            string json = File.ReadAllText(filePath);

            posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        }

        private void SavePosts()
        {
            string json = JsonSerializer.Serialize(posts, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(filePath, json);
        }

        public void AddPost(Post post)
        {
            if (posts.Count == 0)
            {
                post.Id = 1;
            }
            else
            {
                post.Id = posts.Max(p => p.Id) + 1;
            }

            posts.Add(post);
            SavePosts();
        }

        public List<Post> GetPosts()
        {
            return posts;
        }

        public Post? GetPost(int id)
        {
            return posts.FirstOrDefault(p => p.Id == id);
        }
    }
}
