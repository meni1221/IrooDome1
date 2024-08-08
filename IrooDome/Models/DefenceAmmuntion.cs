// שימוש ב-directives להכללת שמות מרחבים נחוצים
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// הגדרת שם המרחב עבור המודלים
namespace IrooDome.Models
{
    // הגדרת מחלקת DefenceAmmuntion
    public class DefenceAmmuntion
    {
        // מאפיין המייצג את המפתח הראשי בטבלה
        [Key]
        public int Id { get; set; }

        // מאפיין עבור שם האמצעי ההגנה, ניתן להיות null
        public string? Name { get; set; }

        // מאפיין עבור הכמות של האמצעי ההגנה
        public int Amount { get; set; }
    }
}
