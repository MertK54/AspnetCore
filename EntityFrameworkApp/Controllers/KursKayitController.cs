using EntityFrameworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Controllers;
public class KursKayitController : Controller
{
    public readonly DataContext _context;
    public KursKayitController(DataContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var KursKayitlari = await _context.KursKayitlari
                                .Include(x => x.Ogrenci)
                                .Include(x => x.Kurs)
                                .ToListAsync();
        return View(KursKayitlari);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
        ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "KursBaslik");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(KursKayit model)
    {
        model.KayitTarihi = DateTime.Now;
        _context.KursKayitlari.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}