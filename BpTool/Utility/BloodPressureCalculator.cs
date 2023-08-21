namespace BpTool.Utility;

public static class BloodPressureCalculator
{
    public static string Get(int systolic, int diastolic)
    {
        switch (true)
        {
            case var _ when systolic < 90 || diastolic < 60:
                return BloodPressureClassification.LOW;
            case var _ when (90 <= systolic && systolic <= 120) && (60 <= diastolic && diastolic <= 80):
                return BloodPressureClassification.NORMAL;
            case var _ when (121 <= systolic && systolic <= 129) && (60 <= diastolic && diastolic <= 80):
                return BloodPressureClassification.ELEVATED;
            case var _ when (130 <= systolic && systolic <= 139) || (80 <= diastolic && diastolic <= 89):
                return BloodPressureClassification.HIGH_STAGE_1;
            case var _ when systolic >= 140 || diastolic >= 90:
                return BloodPressureClassification.HIGH_STAGE_2;
            default:
                return BloodPressureClassification.INVALID;
        }
    }
}