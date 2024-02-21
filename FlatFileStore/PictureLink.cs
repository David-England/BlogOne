using Core;

namespace FlatFileStore
{
	public class PictureLink : IPictureLink
	{
		public string Path { get; }
		public string Caption { get; }

		private PictureLink(string path, string caption)
		{
			Path = path;
			Caption = caption;
		}

		public static PictureLink CreateFromLine(string line)
		{
			var args = line.Split('|');
			if (args.Length < 3) throw new LineParseException("<<PIC has too few elements.", line);
			return new PictureLink(path: args[1].Trim(), caption: args[2].Trim());
		}
	}
}
