namespace Core
{
    public interface IBlog
    {
        public IEnumerable<IBlogElement> BlogElements { get; }
    }
}
