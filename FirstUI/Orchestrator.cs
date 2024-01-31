using Core;
using FlatFileStore;

namespace FirstUI
{
	public static class Orchestrator
	{
		private static IBlogCollection _store = Store.Create("Blogs");

		public static IDictionary<string, IBlog> AllBlogs
		{
			get
			{
				return _store.GetAllBlogs();
			}
		}

		public static IBlog GetBlog(string key) => _store.GetBlog(key);
	}
}
