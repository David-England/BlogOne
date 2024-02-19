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
			string actual = store.GetBlog(blogKey).BlogElements
				.Where(elem => elem is ITableRegular)
				.Select(tab => ((ITableRegular)tab).Cells)
				.Single()[row, col];
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("on_the_midlife_crisis", 2, "Hypothesized explanations")]
		public void FetchHeader(string blogKey, int col, string expected)
		{
			Store store = Store.Create("TestStore");
			string actual = store.GetBlog(blogKey).BlogElements
				.Where(elem => elem is ITableRegular)
				.Select(tab => ((ITableRegular)tab).Headers)
				.Single()[col];
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("on_the_midlife_crisis", "Another year, another day, another table.")]
		public void FetchCaption(string blogKey, string expected)
		{
			Store store = Store.Create("TestStore");
			string actual = store.GetBlog(blogKey).BlogElements
				.Where(elem => elem is ITableRegular)
				.Select(tab => ((ITableRegular)tab).Caption)
				.Single();
			Assert.Equal(expected, actual);
		}
	}
}
