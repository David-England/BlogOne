using Core;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private Dictionary<string, IBlog> _blogs;

        private Store(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            _blogs = files
                .ToDictionary<string, string, IBlog>(Path.GetFileNameWithoutExtension, Blog.Create);
        }

        public static Store Create(string folderPath)
        {
            return new Store(folderPath);
        }

        public IDictionary<string, IBlog> GetAllBlogs() =>
            _blogs.OrderByDescending(kv => kv.Value.CreatedDate).ToDictionary();

        public IEnumerable<IDictionary<string, IBlog>> GetNBlogs(int n)
        {
            for (int i = 0; i < _blogs.Count; i += n)
            {
                yield return _blogs.OrderByDescending(kv => kv.Value.CreatedDate).Skip(i).Take(n)
                    .ToDictionary();
            }
        }

        public IBlog GetBlog(string key)
        {
            return _blogs[key];
        }
    }
}
