namespace TestFlatFileStore
{
	public class RefreshBlogs
	{
		private const string FolderPath = "_RefreshBlogs";
		private const string BlogPath = FolderPath + "/blog.txt";

		[Fact]
		public void InstantiateStoreThenAdd()
		{
			CreateEmptyFolder(FolderPath);
			Store store = Store.Create(FolderPath);

			File.Create(BlogPath).Close();
			File.WriteAllLines(BlogPath, ["01/01/2024 New blog", "My friends, it's a new day."]);

			Assert.Single(store.GetAllBlogs());
		}

		private void CreateEmptyFolder(string path)
		{
			if (Directory.Exists(path)) Directory.Delete(path, recursive: true);
			Directory.CreateDirectory(path);
		}
	}
}
