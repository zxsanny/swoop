using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Swoop.Common.Extensions;

namespace Swoop.Viewer
{
    public class TextBoxWriter : TextWriter
    {
        readonly TextBox output;
        private StringBuilder currentLine;
        private int lineCount;
        private const int MAX_LINES = 100;
            
        public TextBoxWriter(TextBox output)
        {
            this.output = output;
            lineCount = 0;
            currentLine = new StringBuilder();
        }

        public override void Write(char value)
        {
            output.InvokeEx(x =>
            {
                currentLine.Append(value);
                if (value == '\n')
                {
                    x.AppendText(currentLine.ToString());
                    currentLine = new StringBuilder();
                    if (++lineCount > MAX_LINES)
                    {
                        var halfText = x.Text.Length/2;
                        var startIndex = x.Text.IndexOf('\n', halfText) + 1;
                        x.Text = x.Text.Substring(startIndex, x.Text.Length - startIndex);
                        x.Select(x.Text.Length, x.Text.Length);
                        lineCount = 0;
                    }
                }
            });
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
