namespace Core
{
    public interface IBlogCollection
    {
        public IEnumerable<IBlogElement> GetAllBlogs();
        public IEnumerable<IEnumerable<IBlogElement>> GetNBlogs(int n);
    }
}
