using System.IO;
using BpTool.DataLayer;
using BpTool.Types;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BpTool.Utility;

public static class PdfGenerator
{
    public static void SavePdf(List<BloodPressureRecord> bloodPressureRecords)
    {
        Document document = new Document();
        PdfWriter generator = PdfWriter.GetInstance(document, new FileStream(FilePath.GetPdfFilePath(), FileMode.Create));
        document.Open();
        
        PdfPTable table = new PdfPTable(4);
        table.AddCell("Time");
        table.AddCell("Systolic");
        table.AddCell("Diastolic");
        table.AddCell("Classification");

        
        foreach (var record in bloodPressureRecords)
        {
            table.AddCell(record.TimeStamp.ToString("dd/MM/yyyy HH:mm"));
            table.AddCell(record.Systolic.ToString());
            table.AddCell(record.Diastolic.ToString());
            table.AddCell(record.BloodPressureClassification);
        }

        document.Add(table);
        document.Add(new Paragraph($"Average Systolic: {bloodPressureRecords.Average(x => x.Systolic)}"));
        document.Add(new Paragraph($"Average Diastolic: {bloodPressureRecords.Average(x => x.Diastolic)}"));
        
        document.Close();
    }
}