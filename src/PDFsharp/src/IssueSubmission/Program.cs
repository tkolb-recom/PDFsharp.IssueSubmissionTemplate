// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using System.Reflection;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //// NET6FIX - will be removed
            //if (Capabilities.Build.IsCoreBuild)
            //    GlobalFontSettings.FontResolver = new FailsafeFontResolver();

            GlobalFontSettings.FontResolver ??= NewFontResolver.Get();

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


            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);

            XFont font = new XFont("Segoe UI Emoji", 12, XFontStyleEx.Regular, options);
            gfx.DrawString("😢", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            font = new XFont("Arial", 12, XFontStyleEx.Regular, options);
            gfx.DrawString(font.Name, font, XBrushes.Black, new XRect(0, 25, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("\u2259\u221E\u2211", font, XBrushes.Red, new XRect(0, 40, page.Width, page.Height), XStringFormats.Center);

            font = new XFont("Segoe UI", 12, XFontStyleEx.Regular, options);
            gfx.DrawString(font.Name, font, XBrushes.Black, new XRect(0, 65, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("\u2259\u221E\u2211", font, XBrushes.Red, new XRect(0, 80, page.Width, page.Height), XStringFormats.Center);

            font = new XFont("Times New Roman", 12, XFontStyleEx.Regular, options);
            gfx.DrawString(font.Name, font, XBrushes.Black, new XRect(0, 105, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("\u2259\u221E\u2211", font, XBrushes.Red, new XRect(0, 120, page.Width, page.Height), XStringFormats.Center);

            font = new XFont("Cambria Math", 12, XFontStyleEx.Regular, options);
            gfx.DrawString(font.Name, font, XBrushes.Black, new XRect(0, 145, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("\u2259\u221E\u2211", font, XBrushes.Red, new XRect(0, 160, page.Width, page.Height), XStringFormats.Center);

            font = new XFont("Arial Unicode MS", 12, XFontStyleEx.Regular, options);
            gfx.DrawString(font.Name, font, XBrushes.Black, new XRect(0, 185, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("\u2259\u221E\u2211", font, XBrushes.Red, new XRect(0, 200, page.Width, page.Height), XStringFormats.Center);


            // Save the document...
            var filename = IOHelper.CreateTemporaryPdfFileName("IssueTemplate");
            Console.WriteLine($"Filename='{filename}'");
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }
    }
}
