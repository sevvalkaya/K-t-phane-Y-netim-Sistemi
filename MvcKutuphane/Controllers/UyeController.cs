﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLUYELER.OrderByDescending(o => o.ID).ToList().ToPagedList(sayfa, 8);
            return View(degerler);
            /*var degerler = db.TBLUYELER.ToList();
            return View(degerler);*/
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }

            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

            /*if (string.IsNullOrEmpty(p.PERSONAL))
            {
                ViewBag.mesaj = "Lütfen Personel Adı Giriniz.";

            }
            else
            {
                db.TBLPERSONEL.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();*/

        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uye1 = uyekit;
            return View(ktpgcms);
        }
    }
}