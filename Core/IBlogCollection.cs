namespace Core
{
    public interface IBlogCollection
    {
        public IEnumerable<IBlog> GetAllBlogs();
        public IEnumerable<IEnumerable<IBlog>> GetNBlogs(int n);
    }
}
