using System.IO;
using BpTool.Types;
using Newtonsoft.Json;

namespace BpTool.DataLayer;

public sealed class BloodPressureRecordRepository
{
    public List<BloodPressureRecord> GetAll()
    {
        var jsonString = File.ReadAllText(FilePath.GetDataFilePath());
        var jsonData = JsonConvert.DeserializeObject<List<BloodPressureRecord>>(jsonString);
        
        if(jsonData != null)
            return jsonData;

        return new List<BloodPressureRecord>();
    }

    public void Save(List<BloodPressureRecord> bloodPressureRecords)
    {
        var jsonString = JsonConvert.SerializeObject(bloodPressureRecords, Formatting.Indented);
        File.WriteAllText(FilePath.GetDataFilePath(), jsonString);
    }

    public void Clear()
    {
        File.WriteAllText(FilePath.GetDataFilePath(), "");
    }
}