using Core;
using FlatFileStore;

namespace FirstUI
{
	public static class Orchestrator
	{
		private static IBlogCollection LocalStore
		{
			get
			{
				return Store.Create("Blogs");
			}
		}

		public static IDictionary<string, IBlog> AllBlogs
		{
			get
			{
				return LocalStore.GetAllBlogs().OrderByDescending(kv => kv.Value.CreatedDate)
					.ToDictionary();
			}
		}

		public static IBlog GetBlog(string key) => LocalStore.GetBlog(key);
	}
}
