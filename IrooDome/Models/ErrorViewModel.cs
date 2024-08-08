// הגדרת שם המרחב עבור המודלים
namespace IrooDome.Models
{
    // הגדרת מחלקת ErrorViewModel
    public class ErrorViewModel
    {
        // מאפיין עבור מזהה הבקשה, ניתן להיות null
        public string? RequestId { get; set; }

        // מאפיין חישובי הבודק אם יש להציג את מזהה הבקשה
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
