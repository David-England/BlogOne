using Core;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private List<IBlog> _blogs;

        private Store(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            _blogs = files.Select(Blog.Create).ToList<IBlog>();
        }

        public static Store Create(string folderPath)
        {
            return new Store(folderPath);
        }

        public IEnumerable<IBlog> GetAllBlogs() => _blogs.OrderByDescending(b => b.CreatedDate);

        public IEnumerable<IEnumerable<IBlog>> GetNBlogs(int n)
        {
            for (int i = 0; i < _blogs.Count; i += n)
            {
                yield return _blogs.OrderByDescending(b => b.CreatedDate).Skip(i).Take(n);
            }
        }
    }
}
