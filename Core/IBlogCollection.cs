using Microsoft.Extensions.FileProviders;

namespace Core
{
    public interface IBlogCollection
    {
        public IFileProvider ImageFileProvider { get; }
        public IDictionary<string, IBlog> GetAllBlogs();
        public IBlog GetBlog(string key);
    }
}
