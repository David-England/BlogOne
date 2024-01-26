namespace TestFlatFileStore
{
    public class FetchBlogs
    {
        [Fact]
        public void GetAllTitles()
        {
            Store store = Store.Create("TestStore");

            List<string> titles = store.GetAllBlogs().Select(b => b.Title).ToList();

            Assert.Equal("Welcome to my new blog!", titles[0]);
            Assert.Equal("On Cheese", titles[1]);
        }
    }
}