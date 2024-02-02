namespace TestFlatFileStore
{
	public class FetchImageDirectory
	{
		[Fact]
		public void GetImageDirectory()
		{
			Store store = Store.Create("TestStore");

			DirectoryInfo di = new DirectoryInfo(store.ImagesDirectoryPath);
			Assert.Equal("TestStore\\pics", Path.Combine(di.Parent!.Name, di.Name));
		}
	}
}
