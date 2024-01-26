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
    }
}