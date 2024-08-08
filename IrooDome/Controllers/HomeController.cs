// ����� �-directives ������ ���� ������ ������
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// ����� �� ����� ���� ���������
namespace IrooDome.Controllers
{
    // ����� ����� HomeController, ������ �-Controller
    public class HomeController : Controller
    {
        // ��� ���� ������ ���� ���� ������
        private readonly ILogger<HomeController> _logger;

        // ����������� ���� HomeController, ���� ����� ����
        public HomeController(ILogger<HomeController> logger)
        {
            // ���� ����� ����� ���� �����
            _logger = logger;
        }

        // ����� ���� ������ ������ Index
        public IActionResult Index()
        {
            // ����� ������ Index
            return View();
        }

        // ����� ���� ������ ������ Privacy
        public IActionResult Privacy()
        {
            // ����� ������ Privacy
            return View();
        }

        // ����� ������ �������� ResponseCache ������ ����� ������
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // ����� ���� ������ ������ Error �� ���� �����
        public IActionResult Error()
        {
            // ����� ������ Error �� ���� ErrorViewModel ����� �� RequestId
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}