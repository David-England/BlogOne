namespace Core
{
    public interface IBlogCollection
    {
        public IDictionary<string, IBlog> GetAllBlogs();
        public IEnumerable<IDictionary<string, IBlog>> GetNBlogs(int n);
        public IBlog GetBlog(string key);
    }
}
