// שימוש ב-directives להכללת שמות מרחבים נחוצים
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// הגדרת שם המרחב עבור הקונטרולר
namespace IrooDome.Controllers
{
    // הגדרת מחלקת HomeController, היורשת מ-Controller
    public class HomeController : Controller
    {
        // שדה פרטי לקריאה בלבד עבור לוגינג
        private readonly ILogger<HomeController> _logger;

        // קונסטרוקטור עבור HomeController, מקבל פרמטר לוגר
        public HomeController(ILogger<HomeController> logger)
        {
            // השמת פרמטר הלוגר לשדה הפרטי
            _logger = logger;
        }

        // מתודת אקשן להחזרת התצוגה Index
        public IActionResult Index()
        {
            // החזרת התצוגה Index
            return View();
        }

        // מתודת אקשן להחזרת התצוגה Privacy
        public IActionResult Privacy()
        {
            // החזרת התצוגה Privacy
            return View();
        }

        // קישוט המתודה באטריבוט ResponseCache להגדרת מטמון התגובה
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // מתודת אקשן להחזרת התצוגה Error עם מודל שגיאה
        public IActionResult Error()
        {
            // החזרת התצוגה Error עם מודל ErrorViewModel שמכיל את RequestId
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}