namespace TestFlatFileStore
{
    public class FetchBlogs
    {
        [Theory]
        [InlineData(0, "Welcome to my new blog!")]
        [InlineData(1, "On Cheese")]
        public void GetAllTitles(int fileNumber, string title)
        {
            Store store = Store.Create("TestStore");

            List<string> foundTitles = store.GetAllBlogs().Select(b => b.Title).ToList();

            Assert.Equal(title, foundTitles[fileNumber]);
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
    }
}