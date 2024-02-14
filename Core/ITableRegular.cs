namespace Core
{
	public interface ITableRegular : IBlogElement
	{
		public int nRows { get; }
		public int nCols { get; }
		public string[] Headers { get; }
		public string[,] Cells { get; }
		public string Caption { get; }
	}
}
