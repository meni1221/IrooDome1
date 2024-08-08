// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.DAL;
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// הגדרת שם המרחב עבור מודלי התצוגה
namespace IrooDome.ViewModels
{
    // הגדרת מחלקת CreateThreatViewModel
    public class CreateThreatViewModel
    {
        // רשימה של פריטים בתצוגת רשימה עבור ארגוני טרור
        public List<SelectListItem> TerrorOrgs { get; set; }

        // מזהה הארגון שנבחר
        public int OrgId { get; set; }

        // רשימה של פריטים בתצוגת רשימה עבור סוגי איומים
        public List<SelectListItem> Types { get; set; }

        // מזהה סוג האיום שנבחר
        public int ThreatTypeId { get; set; }

        // רשימה של פריטים בתצוגת רשימה עבור איומים
        public List<SelectListItem> Threats { get; set; }

        // מזהה האיום שנבחר
        public int ThreatId { get; set; }
    }
}
