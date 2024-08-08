// הגדרת שם המרחב עבור הכלים והעזר
namespace IrooDome.Utils
{
    // יצירת רשימת ערכים מוגבלת (enum) עבור סטטוס האיום
    public enum ThreatStatus
    {
        // הסטטוס של האיום פעיל
        Active,

        // הסטטוס של האיום אינו פעיל
        Inactive,

        // הסטטוס של האיום נכשל
        Failed,

        // הסטטוס של האיום הצליח
        Succeeded
    }
}
