using Core;
using static System.Reflection.Metadata.BlobBuilder;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private string _folderPath;

        private Dictionary<string, IBlog> Blogs
        {
            get
            {
				string[] files = Directory.GetFiles(_folderPath);
				return files
					.ToDictionary<string, string, IBlog>(Path.GetFileNameWithoutExtension, Blog.Create);
			}
        }

        private Store(string folderPath)
        {
            _folderPath = folderPath;
        }

        public static Store Create(string folderPath)
        {
            return new Store(folderPath);
        }

        public IDictionary<string, IBlog> GetAllBlogs() =>
            Blogs.OrderByDescending(kv => kv.Value.CreatedDate).ToDictionary();

		public IEnumerable<IDictionary<string, IBlog>> GetNBlogs(int n)
        {
            for (int i = 0; i < Blogs.Count; i += n)
            {
                yield return Blogs.OrderByDescending(kv => kv.Value.CreatedDate).Skip(i).Take(n)
                    .ToDictionary();
            }
        }

        public IBlog GetBlog(string key)
        {
            return Blogs[key];
        }
    }
}
