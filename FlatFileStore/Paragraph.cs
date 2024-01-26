using Core;

namespace FlatFileStore
{
    public class Paragraph : IParagraph
    {
        public string Text { get; }

        private Paragraph(string text)
        {
            Text = text;
        }

        public static Paragraph Create(string text)
        {
            return new Paragraph(text);
        }
    }
}
