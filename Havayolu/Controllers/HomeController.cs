using System.Diagnostics;
using Microsoft.Identity.Client;
using Havayolu.Models;
using Havayolu.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;
using Havayolu.Models.doubleModel;

namespace Havayolu.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext _ctx;

        public HomeController(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult cookiePolicy()
        {
            return View();
        }

        public IActionResult institutional()
        {
            return View();
        }

        public IActionResult aboutUs()
        {
            return View();
        }

        public IActionResult adminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult adminLogin(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return RedirectToAction("AdminPanel");
            }
            else
            {
                TempData["error"] = "Hatalý kullanýcý adý veya þifre!";
                return View();
            }
        }

        

        public IActionResult Communication()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult adminPanel()
        {
            return View();
        }

        public IActionResult adminTabloBir()
        {
            var Persons = _ctx.persons.ToList();
            return View(Persons);
        }

        public IActionResult adminTabloÝki()
        {
            var Kullanicilar = _ctx.kullanicilar.ToList();
            return View(Kullanicilar);
        }

        [HttpPost]
        public IActionResult adminPanel(Person Person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.persons.Add(Person);
                _ctx.SaveChanges();
                TempData["msg"] = "Uçuþ Eklendi";
                return RedirectToAction("adminPanel");
            }
            catch (Exception ex) 
            {
                TempData["msg"] = "Uçuþ Eklenemedi!!!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(Kullanici Kullanici)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.kullanicilar.Add(Kullanici);
                _ctx.SaveChanges();
                TempData["msg"] = "Kayýt Edildi";
                return RedirectToAction("login");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Kayýt Edilemedi";
                return View();
            }
        }

        public IActionResult adminKayitSil(int ID)
        {
            try
            {
                var Person = _ctx.persons.Find(ID);
                if (Person != null)
                {
                    _ctx.persons.Remove(Person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("adminTabloBir");
        }

        public IActionResult kullaniciKayitSil(int ID)
        {
            try
            {
                var Kullanici = _ctx.kullanicilar.Find(ID);
                if (Kullanici != null)
                {
                    _ctx.kullanicilar.Remove(Kullanici);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("adminTabloÝki");
        }

        public IActionResult kayitSil(int ID) //Bu silme kodu Privacy için
        {
            try
            {
                var Bilet = _ctx.biletler.Find(ID);
                if (Bilet != null)
                {
                    _ctx.biletler.Remove(Bilet);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Privacy");
        }

        [HttpPost]
        public IActionResult girisYap(string isim, string soyisim, string sifre)
        {
            var kullanici = _ctx.kullanicilar
                .FirstOrDefault(x => x.adi == isim && x.soyadi == soyisim && x.sifre == sifre);

            if (kullanici != null)
            {
                HttpContext.Session.SetString("adi", kullanici.adi);
                HttpContext.Session.SetString("soyadi", kullanici.soyadi);
                HttpContext.Session.SetInt32("kullaniciId", kullanici.Id);

                TempData["msg"] = "Baþarýlý giriþ!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Hatalý giriþ!";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ucuslariGetir(string nereden, string nereye)
        {
            var uygunUcuslar = _ctx.persons
            .Where(x => x.nereden == nereden && x.nereye == nereye)
            .ToList();

            return PartialView("_UcusListesi", uygunUcuslar);
        }





        [HttpPost]
        public IActionResult BiletAl(Bilet bilet)
        {
            var adi = HttpContext.Session.GetString("adi");
            var soyadi = HttpContext.Session.GetString("soyadi");
            var kullaniciId = HttpContext.Session.GetInt32("kullaniciId");

            if (string.IsNullOrEmpty(adi) || string.IsNullOrEmpty(soyadi))
            {
                return RedirectToAction("login");
            }

            bilet.adi = adi;
            bilet.soyadi = soyadi;
            bilet.kullaniciId = kullaniciId.Value;

            _ctx.biletler.Add(bilet);
            _ctx.SaveChanges();

            return RedirectToAction("payment");
        }

        public IActionResult Privacy()
        {
            var adi = HttpContext.Session.GetString("adi");
            var soyadi = HttpContext.Session.GetString("soyadi");
            var kullaniciId = HttpContext.Session.GetInt32("kullaniciId");

            //var kullaniciyaAitBiletler = _ctx.biletler
            //    .Where(x => x.adi == adi && x.soyadi == soyadi)    ad ve soyad a göre bilet leri listeliyordu.
            //    .ToList();

            var kullaniciyaAitBiletler = _ctx.biletler
                .Where(x => x.kullaniciId == kullaniciId)
                .ToList();

            return View(kullaniciyaAitBiletler);
        }

        [HttpGet]
        public IActionResult payment()
        {
            var sonBilet = _ctx.biletler
                .OrderByDescending(b => b.id) // Bu satýrda ki kod Tüm biletleri id deðerine göre azalan sýrayla sýralar. Yani en büyük id en baþta olur. (Yani en son eklenen bilet, Chat GPT den alýndý)
                .FirstOrDefault();

            var model = new doubleModelClass
            {
                kayitListesi = sonBilet != null ? new List<Bilet> { sonBilet } : new List<Bilet>() // Bu kodda sadece son bileti listeliyor
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult payment(doubleModelClass doubleModelClass)
        {
            if (!ModelState.IsValid)
            {
                if (doubleModelClass.yeniKayit.onay)
                {
                    _ctx.kartlar.Add(doubleModelClass.yeniKayit);  // Bu kod bloðu çalýþýyor. Çünkü class da string deðer isteyip html de int deðer giriyorum. Dolayýsýyla bu if çalýþýyor.
                    _ctx.SaveChanges();
                    TempData["msg"] = "Kayýt Edildi";
                    return RedirectToAction("Index");
                }
            }
            try
            {
                if (doubleModelClass.yeniKayit.onay)
                {
                    _ctx.kartlar.Add(doubleModelClass.yeniKayit);
                    _ctx.SaveChanges();
                    TempData["msg"] = "Kayýt Edildi";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Kayýt Edilemedi";
                return View("payment", doubleModelClass);
            }
        }

       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
