// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.DAL;
using IrooDome.Models;
using IrooDome.Utils;
using IrooDome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// הגדרת שם המרחב עבור הקונטרולר
namespace IrooDome.Controllers
{
    // הגדרת מחלקת ThreatController, היורשת מ-Controller
    public class ThreatController : Controller
    {
        // מתודת אקשן להחזרת התצוגה Index
        public IActionResult Index()
        {
            // יצירת רשימה של Threat על ידי הכללת האובייקטים הקשורים (org ו-type)
            List<Threat> threats = Data.Get.Threats
                .Include(t => t.org)   // כולל את הארגון הקשור
                .Include(t => t.type)  // כולל את סוג האיום הקשור
                .ToList();             // המרת התוצאה לרשימה

            // החזרת התצוגה Index עם הרשימה של Threat
            return View(threats);
        }

        // מתודת אקשן להחזרת התצוגה Create
        public IActionResult Create()
        {
            // יצירת רשימה של ThreatAmmunition על ידי המרת הנתונים לרשימה
            List<ThreatAmmunition>? ta = Data.Get.ThreatAmmunitions.ToList();

            // יצירת רשימה של TerrorOrg על ידי המרת הנתונים לרשימה
            List<TerrorOrg>? orgList = Data.Get.TerrorOrgs.ToList();

            // יצירת אובייקט CreateThreatViewModel עם רשימות של סוגים וארגונים
            CreateThreatViewModel model = new CreateThreatViewModel
            {
                Types = ta.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList(),
                TerrorOrgs = orgList.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList()
            };

            // החזרת התצוגה Create עם המודל
            return View(model);
        }

        // מתודת אקשן עבור POST לבקשות יצירה של איום חדש
        [HttpPost]
        public IActionResult Create(CreateThreatViewModel model)
        {
            // מציאת האובייקט TerrorOrg לפי מזהה הארגון
            TerrorOrg? org = Data.Get.TerrorOrgs.Find(model.OrgId);

            // מציאת האובייקט ThreatAmmunition לפי מזהה סוג האיום
            ThreatAmmunition? threatType = Data.Get.ThreatAmmunitions.Find(model.ThreatTypeId);

            // בדיקת תקינות האובייקטים שנמצאו
            if (org != null && threatType != null)
            {
                // יצירת אובייקט Threat חדש עם האובייקטים שנמצאו
                Threat? newThreat = new Threat
                {
                    org = org,
                    type = threatType,
                };

                // הוספת האיום החדש לרשימת האיומים ושמירת השינויים בבסיס הנתונים
                Data.Get.Threats.Add(newThreat);
                Data.Get.SaveChanges();

                // הרצת מתודת StartAttack באשכול חדש
                Task.Run(() => StartAttack(newThreat));
            }

            // הפנייה מחדש למתודת Index
            return RedirectToAction(nameof(Index));
        }

        // מתודה פרטית לביצוע התקפה
        private void StartAttack(Threat threat)
        {
            // הדפסת הודעה עם פרטי האיום שהתחיל
            Console.WriteLine($"Threat {threat.Id} from {threat.org.Name} with {threat.org.Name} started.");

            // שינוי סטטוס האיום לפעיל
            threat.status = ThreatStatus.Active;

            // השהייה לפי זמן התגובה של האיום
            Task.Delay(threat.responseTime * 1000).Wait();

            // הדפסת הודעה עם סיום התקפת האיום
            Console.WriteLine($"Threat {threat.Id} attack finished.");

            // שינוי סטטוס האיום ללא פעיל ושמירת השינויים בבסיס הנתונים
            threat.status = ThreatStatus.Inactive;
            Data.Get.SaveChanges();
        }

        // מתודת אקשן לשיגור איום
        public IActionResult Launch(int id)
        {
            // מציאת האובייקט Threat לפי מזהה האיום
            Threat? t = Data.Get.Threats.Find(id);

            // אם האיום לא נמצא, החזרת NotFound
            if (t == null)
            {
                return NotFound();
            }

            // שינוי סטטוס האיום לפעיל והגדרת זמן השיגור הנוכחי
            t.status = Utils.ThreatStatus.Active;
            t.fired_at = DateTime.Now;

            // שמירת השינויים בבסיס הנתונים
            Data.Get.SaveChanges();

            // יצירת משימת Task חדשה, אך ללא קוד ריצה
            Task task = Task.Run(() => { });

            // הפנייה מחדש למתודת StartAttack (לאחר שיצרנו משימה ללא קוד ריצה)
            return RedirectToAction(nameof(StartAttack));
        }
    }
}
