using Core;

namespace FlatFileStore
{
	public class TableRegular : ITableRegular
	{
		public int nRows { get; }
		public int nCols { get; }
		public string[] Headers { get; }
		public string[,] Cells { get; }
		public string Caption { get; }

		private TableRegular(int nRows, int nCols, string[] headers, string[,] cells, string caption)
		{
			this.nRows = nRows;
			this.nCols = nCols;
			Headers = headers;
			Cells = cells;
			Caption = caption;
		}

		public static TableRegular CreateFromLine(string line)
		{
			var elements = line.Split('¬');

			string[] headers = ParseHeader(elements[1]);
			int nCols = headers.Length;
			string[,] cells = ParseCells(elements[2]);
			int nRows = cells.GetLength(0);
			string caption = elements[3].Trim();

			return new TableRegular(nRows, nCols, headers, cells, caption);


			static string[] ParseHeader(string headerLine) =>
				headerLine.Split('|').Select(s => s.Trim()).ToArray();

			static IEnumerable<string> ParseRow(string rowLine, int shouldBe)
			{
				var cells = rowLine.Split('|').Select(s => s.Trim());
				if (cells.Count() != shouldBe)
					throw new Exception($"Row has incorrect number of cells: \"{rowLine}\"");
				return cells;
			}

			string[,] ParseCells(string tableBodyString)
			{
				var jagged = tableBodyString.Split("||")
					.Select(s => ParseRow(s, shouldBe: nCols).ToArray())
					.ToArray();

				string[,] multi = new string[jagged.Length, nCols];

				for (int i = 0; i < jagged.Length; i++)
					for (int j = 0; j < nCols; j++)
						multi[i, j] = jagged[i][j];

				return multi;
			}
		}
	}
}
