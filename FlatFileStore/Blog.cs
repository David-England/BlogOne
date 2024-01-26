using Core;

namespace FlatFileStore
{
    public class Blog : IBlog
    {
        public string Title { get; }
        public IAuthor Author { get; }
        public ILocation Location { get; }
        public IEnumerable<IBlogElement> BlogElements { get; }

        private Blog(string fullName)
        {
            var lines = File.ReadAllLines(fullName);

            Title = lines[0].Trim();
            Author = new Author();
            Location = new Location();
        }

        public static Blog Create(string fullName)
        {
            return new Blog(fullName);
        }
    }
}
