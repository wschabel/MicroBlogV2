using MicroBlog.Models;
using System.Text.Json;

namespace MicroBlog.Repositories
{
    public class JsonBlogRepository : IBlogRepository
    {
        private readonly string _filePath;
        private List<Post> _posts;

        public JsonBlogRepository(IWebHostEnvironment environment)
        {
            _filePath = Path.Combine(environment.ContentRootPath, "data", "posts.json");
            _posts = new List<Post>();

            LoadPosts();
        }

        private void LoadPosts()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
            }
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post? GetById(int id)
        {
            return _posts.FirstOrDefault(post => post.Id == id);
        }

        public void Add(Post post)
        {
            post.Id = _posts.Count > 0 ? _posts.Max(p => p.Id) + 1 : 1;
            _posts.Add(post);
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(_posts, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }
    }
}
