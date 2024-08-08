// שימוש ב-directives להכללת שמות מרחבים נחוצים
using System.ComponentModel.DataAnnotations;

// הגדרת שם המרחב עבור המודלים
namespace IrooDome.Models
{
    // הגדרת מחלקת ThreatAmmunition
    public class ThreatAmmunition
    {
        // מאפיין המייצג את המפתח הראשי בטבלה
        [Key]
        public int Id { get; set; }

        // מאפיין עבור שם האיום, ניתן להיות null
        public string? Name { get; set; }

        // מאפיין עבור מהירות האיום
        public int Speed { get; set; }
    }
}
