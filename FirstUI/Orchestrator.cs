using Core;
using FlatFileStore;

namespace FirstUI
{
	public static class Orchestrator
	{
		private static IBlogCollection _store = Store.Create("Blogs");

		public static IEnumerable<IBlog> AllBlogs
		{
			get
			{
				return _store.GetAllBlogs();
			}
		}

		public static int IndexOf(IBlog blog)
		{
			return AllBlogs.Reverse().ToList().IndexOf(blog);
		}
	}
}
