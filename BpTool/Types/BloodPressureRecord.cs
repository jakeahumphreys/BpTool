using BpTool.Utility;

namespace BpTool.Types;

public sealed class BloodPressureRecord
{
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public int Systolic { get; set; }
    public int Diastolic { get; set; }
    public string BloodPressureClassification { get; set; }
}

public sealed class BloodPressureRecordViewModel
{
    public int Systolic { get; set; }
    public int Diastolic { get; set; }
}