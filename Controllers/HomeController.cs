using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Rotativa.AspNetCore;
using StudentExportApp.Repositories.Interfaces;

namespace StudentExportApp.Controllers;

public class HomeController : Controller
{
    private readonly IStudentRepository _repo;
    public HomeController(IStudentRepository repo) => _repo = repo;

    // Menampilkan Tabel Mahasiswa
    public IActionResult Index()
    {
        var data = _repo.GetAll();
        return View(data);
    }

    // Download Excel
    [HttpGet("download-excel")]
    public IActionResult DownloadExcel()
    {
        var items = _repo.GetAll();
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Mahasiswa");
        // Header
        ws.Cell(1, 1).Value = "NIM";
        ws.Cell(1, 2).Value = "Nama";
        ws.Cell(1, 3).Value = "Email";
        ws.Cell(1, 4).Value = "Fakultas";
        ws.Cell(1, 5).Value = "Jurusan";
        int r = 2;
        foreach (var s in items)
        {
            ws.Cell(r, 1).Value = s.Nim;
            ws.Cell(r, 2).Value = s.Nama;
            ws.Cell(r, 3).Value = s.Email;
            ws.Cell(r, 4).Value = s.Fakultas;
            ws.Cell(r, 5).Value = s.Jurusan;
            r++;
        }
        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return File(ms.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "mahasiswa.xlsx");
    }

    // Download PDF
    [HttpGet("download-pdf")]
    public IActionResult DownloadPdf()
    {
        var model = _repo.GetAll();
        return new ViewAsPdf("PdfTemplate", model)
        {
            FileName = "mahasiswa.pdf",
            PageSize = Rotativa.AspNetCore.Options.Size.A4
        };
    }
    
}