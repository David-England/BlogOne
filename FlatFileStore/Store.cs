using Core;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private string _folderPath;

        public string ImagesDirectoryPath
        {
            get
            {
                return new DirectoryInfo(Path.Combine(_folderPath, "pics")).FullName;
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
