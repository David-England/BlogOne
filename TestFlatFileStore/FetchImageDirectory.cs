using Microsoft.Extensions.FileProviders;

namespace TestFlatFileStore
{
	public class FetchImageDirectory
	{
		[Fact]
		public void ImageExists()
		{
			Store store = Store.Create("TestStore");
			Assert.True(store.ImageFileProvider.GetFileInfo("dvdiag.png").Exists);
		}
	}
}
