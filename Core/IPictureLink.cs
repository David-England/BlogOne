namespace Core
{
	public interface IPictureLink : IBlogElement
	{
		public string Path { get; }
		public string Caption { get; }
	}
}
