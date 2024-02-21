namespace FlatFileStore
{
	public class LineParseException : Exception
	{
		public string Line { get; }

		public LineParseException(string preamble, string line) : base($"SERVER ERROR: {preamble} LINE: {line}")
		{
			Line = line;
		}
	}
}
