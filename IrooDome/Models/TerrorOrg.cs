// שימוש ב-directives להכללת שמות מרחבים נחוצים
using System.ComponentModel.DataAnnotations;

// הגדרת שם המרחב עבור המודלים
namespace IrooDome.Models
{
    // הגדרת מחלקת TerrorOrg
    public class TerrorOrg
    {
        // מאפיין המייצג את המפתח הראשי בטבלה
        [Key]
        public int Id { get; set; }

        // מאפיין עבור המרחק, שדה חובה
        public int Distance { get; set; }

        // מאפיין עבור שם הארגון, ניתן להיות null
        public string? Name { get; set; }

        // מאפיין עבור מיקום הארגון, ניתן להיות null
        public string? Location { get; set; }
    }
}
