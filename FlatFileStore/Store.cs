using Core;

namespace FlatFileStore
{
    public class Store : IBlogCollection
    {
        private List<IBlog> _blogs = new List<IBlog>();

        private Store(string folderPath)
        {
            DirectoryInfo folder = Directory.CreateDirectory(folderPath);

            foreach (var item in folder.EnumerateFiles())
            {
                //
            }
        }

        public Store Create(string folderPath)
        {
            return new Store(folderPath);
        }

        public IEnumerable<IBlog> GetAllBlogs() => _blogs;

        public IEnumerable<IEnumerable<IBlog>> GetNBlogs(int n)
        {
            for (int i = 0; i < _blogs.Count; i += n)
            {
                yield return _blogs.Skip(i).Take(n);
            }
        }
    }
}
