using MicroBlog.Models;

namespace MicroBlog.Repositories
{
    public class InMemoryBlogRepository : IBlogRepository
    {
        private readonly List<Post> _posts = new();

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
        }
    }
}
