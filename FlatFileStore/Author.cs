using Core;

namespace FlatFileStore
{
    public class Author : IAuthor
    {
        public string Forename { get; } = "David";
        public string MiddleNames { get; } = "John Harcourt";
        public string Surname { get; } = "England";
        public string MiddleNameInitials { get; } = "JH";
    }
}
