using System.IO;

namespace BpTool.DataLayer;

public sealed class FilePath
{
    public static string GetDataFilePath()
    {
        var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var path = Path.Combine(myDocuments, "BloodPressureRecords.json");

        return path;
    }

    public static string GetPdfFilePath()
    {
        var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var path = Path.Combine(myDocuments, $"BpExport_{DateTime.Now.ToString("ddMMyyyy_HHmm")}.pdf");

        return path;
    }
}