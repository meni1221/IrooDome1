// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// הגדרת שם המרחב עבור המודלים
namespace IrooDome.Models
{
    // הגדרת מחלקת Threat
    public class Threat
    {
        // קונסטרוקטור שמאתחל את הסטטוס ל-Inactive
        public Threat()
        {
            status = ThreatStatus.Inactive;
        }

        // מאפיין המייצג את המפתח הראשי בטבלה
        [Key]
        public int Id { get; set; }

        // מאפיין שאינו ממופה לטבלה בבסיס הנתונים
        [NotMapped]
        // מאפיין לחישוב זמן התגובה של האיום
        public int responseTime
        {
            get
            {
                // חישוב זמן התגובה לפי מרחק הארגון ומהירות סוג האיום
                return org.Distance / type.Speed;
            }
        }

        // מאפיין עבור הארגון שקשור לאיום
        public TerrorOrg org { get; set; }

        // מאפיין עבור סוג האיום
        public ThreatAmmunition type { get; set; }

        // מאפיין עבור הסטטוס של האיום (InActive / Active / Failed / Succeeded)
        public ThreatStatus status { get; set; }

        // מאפיין עבור התאריך והשעה שבהם האיום שוגר, ניתן להיות null
        public DateTime? fired_at { get; set; }
    }
}
