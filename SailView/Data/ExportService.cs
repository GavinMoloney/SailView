using SailView.Data.Models;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace SailView.Data
{
    public class ExportService
    {
        public static MemoryStream CreatePdf(List<BoatDetails> boatDetails)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Create a PDF grid.
            PdfGrid pdfGrid = new PdfGrid();

            //Add values to list
            List<object> data = new List<object>();
            foreach (var boat in boatDetails)
            {
                data.Add(new
                {
                    BoatName = boat.BoatName,
                    SailNumber = boat.SailNumber,
                    BoatType = boat.BoatType,
                    CreatedDate = boat.CreatedDate
                });
            }

            //Assign data source.
            pdfGrid.DataSource = data;

            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(0, 0));

            //Save the document.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document.
            document.Close(true);

            return stream;
        }

        //Not Working, null reference exception
        public static MemoryStream CreateSingleRacePdf(List<Races> races, List<BoatRaces> boatRaces)
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Add a page.
            PdfPage page = document.Pages.Add();

            // Create a PDF grid.
            PdfGrid pdfGrid = new PdfGrid();

            List<object> data = new List<object>();
            foreach (var race in races)
            {
                foreach (var boat in boatRaces)
                {
                    data.Add(new
                    {
                        RaceName = race.Id,
                        RaceDate = race.RaceId,
                        RaceTime = race.CreatedDate,
                        BoatName = boat.BoatDetails.BoatName,
                        BoatType = boat.BoatDetails.BoatType,
                        SailNumber = boat.BoatDetails.SailNumber,
                        Position = boat.Position,
                        Timing = boat.TimingRecord,
                        Status = boat.FinishingStatus
                    });
                }
            }

            // Assign the data source.
            pdfGrid.DataSource = data;

            // Set the cell style.
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            // Apply the style to individual cells.
            for (int i = 0; i < pdfGrid.Rows.Count; i++)
            {
                for (int j = 0; j < pdfGrid.Columns.Count; j++)
                {
                    pdfGrid.Rows[i].Cells[j].Style = cellStyle;
                }
            }

            // Draw the table on the PDF page.
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            pdfGrid.Draw(page, new PointF(0, 0), layoutFormat);

            // Save the PDF document to a MemoryStream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);

            return stream;
        }







        /*
        //Export data to PDF document.
        public static MemoryStream CreateRacePdf(List<BoatRaces> races)
        {
            if (races == null)
            {
                throw new ArgumentNullException("Forecast cannot be null");
            }
            //Create a new PDF document.
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;
                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a service and Exporting the data to PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;
                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;
                //Applying built-in style to the PDF grid.
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

                //Assign data source.
                pdfGrid.DataSource = races;
                pdfGrid.Style.Font = contentFont;
                //Draw PDF grid into the PDF page.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream.
                    pdfDocument.Save(stream);
                    //Closing the PDF document.
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }*/
    }
}
