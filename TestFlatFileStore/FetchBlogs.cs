namespace TestFlatFileStore
{
    public class FetchBlogs
    {
        [Theory]
        [InlineData(0, "Welcome to my new blog!")]
        [InlineData(1, "On Cheese")]
        public void GetAllTitles(int fileNumber, string expectedTitle)
        {
            Store store = Store.Create("TestStore");

            string title = store.GetAllBlogs().ToList()[fileNumber].Title;

            Assert.Equal(expectedTitle, title);
        }

        [Theory]
        [InlineData(0, "Welcome to my new blog!|On Cheese|On Love")]
        [InlineData(1, "On Murder|On Sewage|On Stars")]
        [InlineData(2, "On the Midlife Crisis")]
        public void GetNTitles(int batchNumber, string expectedTitle)
        {
            Store store = Store.Create("TestStore");

            var titlesInBatch = store.GetNBlogs(3).ToList()[batchNumber].Select(blog => blog.Title);

            Assert.Equal(expectedTitle, string.Join('|', titlesInBatch));
        }

        [Theory]
        [InlineData(0, "This is my first blog. Whatevs.")]
        [InlineData(1, "Wherein I present a \"fresh\" study on the topic of cheese.|Cheese smells.")]
        public void GetBlogContents(int fileNumber, string expectedContent)
        {
            Store store = Store.Create("TestStore");

            var allParagraphs = store.GetAllBlogs().ToList()[fileNumber].BlogElements
                .Select(element => ((Paragraph)element).Text);

            Assert.Equal(expectedContent, string.Join('|', allParagraphs));
        }

        [Fact]
        public void GetBlogAuthors()
        {
            Store store = Store.Create("TestStore");

            var authors = store.GetAllBlogs().Select(b => b.Author);

            foreach (var author in authors)
                Assert.Equal("David England", $"{author.Forename} {author.Surname}");
        }

        [Fact]
        public void GetBlogLocations()
        {
            Store store = Store.Create("TestStore");

            var locations = store.GetAllBlogs().Select(b => b.Location);

            foreach (var location in locations)
                Assert.Equal("Cheltenham", location.Name);
        }
    }
}