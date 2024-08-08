// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.Utils;

// הגדרת שם המרחב עבור מודלי התצוגה
namespace IrooDome.ViewModels
{
    // הגדרת מחלקת ThreatViewModel
    public class ThreatViewModel
    {
        // מזהה האיום
        public int Id { get; set; }

        // שם הארגון הקשור לאיום
        public string? OrgName { get; set; }

        // מיקום הארגון הקשור לאיום
        public string? OrgLocation { get; set; }

        // סוג האיום
        public string? ThreatType { get; set; }

        // זמן התגובה של האיום
        public int ResponseTime { get; set; }

        // סטטוס האיום
        public ThreatStatus Status { get; set; }
    }
}
