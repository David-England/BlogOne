using Core;

namespace TestFlatFileStore
{
	public class FetchTable
	{
		[Theory]
		[InlineData("on_the_midlife_crisis", 1, 1, "Large, annual, champagne-fuelled parties required")]
		[InlineData("on_the_midlife_crisis", 2, 0, "50")]
		public void FetchCell(string blogKey, int row, int col, string expected)
		{
			Store store = Store.Create("TestStore");
			string actual = FetchSingleTableRegular(store, blogKey).Cells[row, col];
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("on_the_midlife_crisis", 2, "Hypothesized explanations")]
		public void FetchHeader(string blogKey, int col, string expected)
		{
			Store store = Store.Create("TestStore");
			string actual = FetchSingleTableRegular(store, blogKey).Headers[col];
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("on_the_midlife_crisis", "Another year, another day, another table.")]
		public void FetchCaption(string blogKey, string expected)
		{
			Store store = Store.Create("TestStore");
			string actual = FetchSingleTableRegular(store, blogKey).Caption;
			Assert.Equal(expected, actual);
		}

		private ITableRegular FetchSingleTableRegular(Store store, string key) =>
			(ITableRegular)store.GetBlog(key).BlogElements.Single(elem => elem is ITableRegular);
	}
}
