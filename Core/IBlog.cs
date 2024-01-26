namespace Core
{
    public interface IBlog
    {
        public string Title { get; }
        public IAuthor Author { get; }
        public ILocation Location { get; }
        public IEnumerable<IBlogElement> BlogElements { get; }
    }
}
