using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace imgtopdf
{
	class Program
	{
		public const string printerName = "Microsoft Print to PDF";
		static void Main(string[] args)
		{
			var printer = new PrintDocument();
			printer.PrinterSettings.PrinterName = printerName;

			Queue<Image> images = new Queue<Image>();
			Console.WriteLine("Printing");
			var sortedArgs = args.OrderBy(x => x).ToArray();
			foreach (string img in sortedArgs)
			{
				if (System.IO.File.Exists(img))
				{
					Console.WriteLine(System.IO.Path.GetFileName(img));
					images.Enqueue((Image)Bitmap.FromFile(img));
				}
			}

			printer.PrintPage += (object sender, PrintPageEventArgs e) =>
			{
				e.Graphics.DrawImage(images.Dequeue(), e.PageBounds);
				e.HasMorePages = images.Count != 0;
			};

			if (images.Count > 0)
			{
				printer.Print();
			}
		}
	}
}
