namespace TestFlatFileStore
{
	public class RefreshBlogs
	{
		private string _blogPath = "WithOneBlog/blog.txt";

		[Fact]
		public void InstantiateStoreThenAdd()
		{
			new FileInfo(_blogPath).Delete();
			Store store = Store.Create("WithOneBlog");

			File.Create(_blogPath).Close();
			File.WriteAllLines(_blogPath, ["01/01/2024 New blog", "My friends, it's a new day."]);

			Assert.Single(store.GetAllBlogs());
		}
	}
}
