// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.DAL;
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;

// הגדרת שם המרחב עבור הקונטרולר
namespace IrooDome.Controllers
{
    // הגדרת מחלקת ManagerController, היורשת מ-Controller
    public class ManagerController : Controller
    {
        // מתודת אקשן להחזרת התצוגה Index
        public IActionResult Index()
        {
            // יצירת רשימה של DefenceAmmuntion על ידי המרת הנתונים לרשימה
            List<DefenceAmmuntion> Defences = Data.Get.DefenceAmmuntions.ToList();
            // החזרת התצוגה Index עם הרשימה של DefenceAmmuntion
            return View(Defences);
        }

        // מתודת אקשן לעדכון כמות של DefenceAmmuntion לפי מזהה
        public IActionResult UpdateDefenceAmmuntion(int dfid, int amount)
        {
            // חיפוש DefenceAmmuntion לפי מזהה
            DefenceAmmuntion? da = Data.Get.DefenceAmmuntions.Find(dfid);
            // עדכון השדה Amount עם הערך החדש
            da.Amount = amount;
            // שמירת השינויים בבסיס הנתונים
            Data.Get.SaveChanges();
            // הפנייה מחדש למתודת Index
            return RedirectToAction(nameof(Index));
        }
    }
}

