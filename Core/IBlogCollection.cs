namespace Core
{
    public interface IBlogCollection
    {
        public IDictionary<string, IBlog> GetAllBlogs();
        public IBlog GetBlog(string key);
    }
}
