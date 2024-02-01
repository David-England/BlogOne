namespace TestFlatFileStore
{
    public class FetchBlogs
    {
        [Theory]
        [InlineData(3, "On Stars")]
        [InlineData(5, "On Cheese")]
        [InlineData(6, "Welcome to my new blog!")]
        public void GetAllTitles(int fileNumber, string expectedTitle)
        {
            Store store = Store.Create("TestStore");

            string title = store.GetAllBlogs().Values.ToList()[fileNumber].Title;

            Assert.Equal(expectedTitle, title);
        }

        [Theory]
        [InlineData(0, "On the Midlife Crisis|On Murder|On Sewage")]
        [InlineData(1, "On Stars|On Love|On Cheese")]
        [InlineData(2, "Welcome to my new blog!")]
        public void GetNTitles(int batchNumber, string expectedTitle)
        {
            Store store = Store.Create("TestStore");

            var titlesInBatch = store.GetNBlogs(3).ToList()[batchNumber]
                .Select(kv => kv.Value.Title);

            Assert.Equal(expectedTitle, string.Join('|', titlesInBatch));
        }

        [Theory]
        [InlineData("my_first_blog", "This is my first blog. Whatevs.")]
        [InlineData("on_cheese", "Wherein I present a \"fresh\" study on the topic of cheese.|Cheese smells.")]
        public void GetBlogByKey(string key, string expectedContent)
        {
            Store store = Store.Create("TestStore");
            var paragraphs = store.GetBlog(key).BlogElements.Select(element => ((Paragraph)element).Text);
			Assert.Equal(expectedContent, string.Join('|', paragraphs));
        }

        [Theory]
        [InlineData(0, "02/03/2024")]
        [InlineData(1, "03/01/2024")]
        public void GetCreatedDates(int fileNumber, string expectedDate)
        {
            Store store = Store.Create("TestStore");

            DateTime dt = store.GetAllBlogs().Values.ToList()[fileNumber].CreatedDate;

            Assert.Equal(expectedDate, dt.ToString("dd/MM/yyyy"));
        }

        [Theory]
        [InlineData(5, "Wherein I present a \"fresh\" study on the topic of cheese.|Cheese smells.")]
        [InlineData(6, "This is my first blog. Whatevs.")]
        public void GetBlogContents(int fileNumber, string expectedContent)
        {
            Store store = Store.Create("TestStore");

            var allParagraphs = store.GetAllBlogs().Values.ToList()[fileNumber].BlogElements
                .Select(element => ((Paragraph)element).Text);

            Assert.Equal(expectedContent, string.Join('|', allParagraphs));
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