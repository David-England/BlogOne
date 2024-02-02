namespace Core
{
    public interface IBlogCollection
    {
        public string ImagesDirectoryPath { get; }
        public IDictionary<string, IBlog> GetAllBlogs();
        public IBlog GetBlog(string key);
    }
}
