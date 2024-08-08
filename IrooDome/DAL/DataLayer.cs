// שימוש ב-directives להכללת שמות מרחבים נחוצים
using Microsoft.EntityFrameworkCore;
using IrooDome.Models;
using System;

// הגדרת שם המרחב עבור שכבת הנתונים
namespace IrooDome.DAL
{
    // קלאס שמייצג את שכבת הנתונים, יורש מקלאס בשם DbContext
    public class DataLayer : DbContext
    {
        // קונסטרקטור שמקבל מחרוזת חיבור ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            // הבטחת יצירת מסד הנתונים אם הוא לא קיים
            Database.EnsureCreated();

            // הכנסה של נתונים בפעם הראשונה
            Seed();
        }

        // יצירת טבלה בדאטא בייס עבור DefenceAmmuntion
        public DbSet<DefenceAmmuntion> DefenceAmmuntions { get; set; }

        // יצירת טבלה בדאטא בייס עבור TerrorOrg
        public DbSet<TerrorOrg> TerrorOrgs { get; set; }

        // יצירת טבלה בדאטא בייס עבור Threat
        public DbSet<Threat> Threats { get; set; }

        // יצירת טבלה בדאטא בייס עבור ThreatAmmunition
        public DbSet<ThreatAmmunition> ThreatAmmunitions { get; set; }

        // פונקציה להכנסת ערכים ראשוניים
        private void Seed()
        {
            // בדיקה אם אין ערכים בטבלת DefenceAmmuntions
            if (!DefenceAmmuntions.Any())
            {
                // יצירת ערכים ראשוניים והוספתם לטבלה
                DefenceAmmuntion defence1 = new DefenceAmmuntion { Name = "Iron Dome Missle", Amount = 100 };
                DefenceAmmuntion defence2 = new DefenceAmmuntion { Name = "Patriot Missle", Amount = 50 };
                DefenceAmmuntions.AddRange(defence1, defence2);
                SaveChanges();
            }

            // בדיקה אם אין ערכים בטבלת TerrorOrgs
            if (!TerrorOrgs.Any())
            {
                // יצירת ערכים ראשוניים והוספתם לטבלה
                TerrorOrgs.AddRange(
                    new TerrorOrg { Name = "Hamas", Location = "Lebanon", Distance = 45 },
                    new TerrorOrg { Name = "Hezbollah", Location = "Lebanon", Distance = 200 },
                    new TerrorOrg { Name = "Houthi", Location = "Yamen", Distance = 2377 },
                    new TerrorOrg { Name = "Iran", Location = "Iran", Distance = 1600 }
                );
                SaveChanges();
            }

            // בדיקה אם אין ערכים בטבלת ThreatAmmunitions
            if (!ThreatAmmunitions.Any())
            {
                // יצירת ערכים ראשוניים והוספתם לטבלה
                ThreatAmmunitions.AddRange(
                    new ThreatAmmunition { Name = "Balisti", Speed = 18000 },
                    new ThreatAmmunition { Name = "Rocket", Speed = 880 },
                    new ThreatAmmunition { Name = "Katbam", Speed = 300 }
                );
                SaveChanges();
            }

            // בדיקה אם אין ערכים בטבלת Threats
            if (!Threats.Any())
            {
                // מציאת האובייקטים המתאימים לפי שם
                TerrorOrg? Hamas = TerrorOrgs.FirstOrDefault(t => t.Name == "Hamas");
                ThreatAmmunition? Rocket = ThreatAmmunitions.FirstOrDefault(t => t.Name == "Rocket");

                // בדיקה אם האובייקטים נמצאו
                if (Hamas != null && Rocket != null)
                {
                    // יצירת ערכים ראשוניים והוספתם לטבלה
                    Threats.AddRange(
                        new Threat
                        {
                            org = Hamas,
                            type = Rocket,
                        }
                    );
                    SaveChanges();
                }
            }
        }

        // פונקציה שמחזירה את אפשרויות ההתחברות למסד הנתונים
        private static DbContextOptions GetOptions(string connectionString)
        {
            // שימוש ב-SqlServerDbContextOptionsExtensions לקבלת אפשרויות ההתחברות
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
