﻿using Core;
using System.Globalization;

namespace FlatFileStore
{
    public class Blog : IBlog
    {
        public string Title { get; }
        public DateTime CreatedDate { get; }
        public IAuthor Author { get; }
        public ILocation Location { get; }
        public IEnumerable<IBlogElement> BlogElements { get; }

        private Blog(string fullName)
        {
            var lines = File.ReadAllLines(fullName);

            Title = lines[0].Substring(10).Trim();
            CreatedDate = DateTime.Parse(lines[0].Substring(0, 10));
            Author = new Author();
            Location = new Location();
            BlogElements = lines.Skip(1).Select(Paragraph.Create);
        }

        public static Blog Create(string fullName)
        {
            return new Blog(fullName);
        }
    }
}
