using Core;
using Microsoft.Extensions.FileProviders;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private string _folderPath;

        public IFileProvider ImageFileProvider
        {
            get
            {
                var di = new DirectoryInfo(Path.Combine(_folderPath, "pics")).FullName;
                return new PhysicalFileProvider(di);
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

        public IDictionary<string, IBlog> GetAllBlogs()
        {
			string[] files = Directory.GetFiles(_folderPath);
			return files
				.ToDictionary<string, string, IBlog>(Path.GetFileNameWithoutExtension, Blog.Create);
		}

        public IBlog GetBlog(string key)
        {
            return GetAllBlogs()[key];
        }
    }
}
