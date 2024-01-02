// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using System.Reflection;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Create a new PDF document.
            var document = new PdfDocument();
            document.Info.Title = "PDFsharp Issue Template";
            document.Info.Author = "Your Name";
            document.Info.Subject = "Demonstrate an issue of PDFsharp";
            document.PageLayout = PdfPageLayout.SinglePage;

            // Create an empty page in this document.
            var page = document.AddPage();

            // Get an XGraphics object for drawing on this page.
            var gfx = XGraphics.FromPdfPage(page);

            // Create a font.
            var font = new XFont("Arial", 20);

            // Draw the text.
            gfx.DrawString("Minimal, reproducible example", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            // Save the document...
            var filename = Path.ChangeExtension(Path.GetRandomFileName(), "pdf");
            filename = $"IssueTemplate-{filename}";

            Console.WriteLine($"Filename='{filename}'");
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }
    }
}
