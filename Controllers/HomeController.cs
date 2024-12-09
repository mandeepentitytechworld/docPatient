using DocPatient.Models;
using DocPatient.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DocPatient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDocService docService;

        public HomeController(ILogger<HomeController> logger, IDocService docService)
        {
            _logger = logger;
            this.docService = docService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await docService.GetDocs();
            return View(result);
        }

        public async Task<IActionResult> Patients(int docId)
        {
            var result = await docService.GetDocsPatients(docId);
            return PartialView("Views/Home/_patients.cshtml", result);
        }

        public async Task<IActionResult> Allergies(int pId)
        {
            var result = await docService.GetPatientAllergies(pId);
            return PartialView("Views/Home/_allergies.cshtml", result);
        }

        public async Task<IActionResult> Medications(int pId)
        {
            var result = await docService.GetPatientMedications(pId);
            return PartialView("Views/Home/_medications.cshtml", result);
        }

        public async Task<IActionResult> Appointments(int pId, int dId)
        {
            var result = await docService.GetAppointments(pId, dId);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
