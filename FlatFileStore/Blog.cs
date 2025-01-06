using Core;
using System.Globalization;

namespace FlatFileStore
{
    public class Blog : IBlog
    {
        private readonly CultureInfo _britishCulture = new CultureInfo("en-GB");

        public string Title { get; }
        public string Topic { get; }
        public DateTime CreatedDate { get; }
        public IAuthor Author { get; }
        public ILocation Location { get; }
        public IEnumerable<IBlogElement> BlogElements { get; }

        private Blog(string fullName)
        {
            var lines = File.ReadAllLines(fullName);

            Title = lines[0].Substring(10).Trim();
            CreatedDate = DateTime.Parse(lines[0].Substring(0, 10), _britishCulture);
            Topic = lines[1].Trim();
            Author = new Author();
            Location = new Location();
            BlogElements = lines.Skip(2).Select(CreateBlogElement);
        }

        public static Blog Create(string fullName)
        {
            return new Blog(fullName);
        }

        private static IBlogElement CreateBlogElement(string line)
        {
            switch (line.Substring(0, Math.Min(5, line.Length)))
            {
                case "<<PIC":
                    return PictureLink.CreateFromLine(line);
                case "<<TAB":
                    return TableRegular.CreateFromLine(line);
                default:
                    return Paragraph.Create(line);
            }
        }
    }
}
