namespace TestFlatFileStore
{
    public class FetchBlogs
    {
        [Theory]
        [InlineData(0, "Welcome to my new blog!")]
        [InlineData(1, "On Cheese")]
        [InlineData(3, "On Stars")]
        public void GetAllTitles(int fileNumber, string expectedTitle)
        {
            Store store = Store.Create("TestStore");

            string title = store
                .GetAllBlogs()
                .Values
                .OrderBy(b => b.CreatedDate)
                .ToList()[fileNumber]
                .Title;

            Assert.Equal(expectedTitle, title);
        }

        [Theory]
        [InlineData("my_first_blog", "This is my first blog. Whatevs.")]
        [InlineData("on_cheese", "Wherein I present a \"fresh\" study on the topic of cheese.|Cheese smells.")]
        public void GetBlogContents(string key, string expectedContent)
        {
            Store store = Store.Create("TestStore");
            var paragraphs = store.GetBlog(key).BlogElements.Select(element => ((Paragraph)element).Text);
			Assert.Equal(expectedContent, string.Join('|', paragraphs));
        }

        [Theory]
        [InlineData("my_first_blog", "Announcements")]
        [InlineData("on_cheese", "Deep Talk")]
        public void GetBlogTopics(string key, string expectedTopic)
        {
            Store store = Store.Create("TestStore");
            Assert.Equal(expectedTopic, store.GetBlog(key).Topic);
        }

        [Theory]
        [InlineData("on_the_midlife_crisis", "02/03/2024")]
        [InlineData("on_murder", "03/01/2024")]
        public void GetCreatedDates(string key, string expectedDate)
        {
            Store store = Store.Create("TestStore");
            Assert.Equal(expectedDate, store.GetBlog(key).CreatedDate.ToString("dd/MM/yyyy"));
        }

        [Fact]
        public void GetBlogAuthors()
        {
            Store store = Store.Create("TestStore");

            var authors = store.GetAllBlogs().Select(kv => kv.Value.Author);

            foreach (var author in authors)
                Assert.Equal("David England", $"{author.Forename} {author.Surname}");
        }

        [Fact]
        public void GetBlogLocations()
        {
            Store store = Store.Create("TestStore");

            var locations = store.GetAllBlogs().Select(kv => kv.Value.Location);

            foreach (var location in locations)
                Assert.Equal("Cheltenham", location.Name);
        }
    }
}