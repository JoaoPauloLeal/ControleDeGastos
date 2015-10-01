using ControleDeGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeGastos.Controllers
{
    public class GastosController : Controller
    {
        GastosRepositorio gastosrepositorio = new GastosRepositorio();
        // GET: Gastos
        public ActionResult Gastos()
        {
            var gastos = gastosrepositorio.getAll();
            return View(gastos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Gastos gastos)
        {
            gastosrepositorio.Create(gastos);
            return RedirectToAction("Gastos");
        }
        public ActionResult Delete(int id)
        {
            int del;
            del = gastosrepositorio.Delete(id);
            ViewBag.erro = del;
            return RedirectToAction("Gastos");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Gastos gastos = gastosrepositorio.GetOne(id);
            return View(gastos);
        }
        [HttpPost]
        public ActionResult Update(Gastos pggastos)
        {
            gastosrepositorio.Update(pggastos);
            return RedirectToAction("Gastos");
        }
    }
}