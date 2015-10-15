using ControleDeGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeGastos.Controllers
{
    public class DespesasController : Controller
    {
        DespesasRepositorio despesasrepositorio = new DespesasRepositorio();
        GastosRepositorio gastosrepositorio = new GastosRepositorio();
        // GET: Despesas
        public ActionResult Despesas()
        {
            var despesas = despesasrepositorio.getAll();
            return View(despesas);
        }
        [HttpPost]
        public ActionResult Consulta(DateTime cData)
        {
            var despesas = despesasrepositorio.Consulta(cData);
            return View(despesas);
        }
        public ActionResult Create()
        {
            List<Gastos> sGastos = new List<Gastos>(gastosrepositorio.getAll());
            ViewBag.sGastos = sGastos;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Despesas pDespesas)
        {
            List<Gastos> sGastos = new List<Gastos>(gastosrepositorio.getAll());
            ViewBag.sGastos = sGastos;

            if (ModelState.IsValid)
            {
                despesasrepositorio.Create(pDespesas);
                return RedirectToAction("Despesas");
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            List<Gastos> sGastos = new List<Gastos>(gastosrepositorio.getAll());
            ViewBag.sGastos = sGastos;
            var despesa = despesasrepositorio.GetOne(id);
            return View(despesa);
        }
        [HttpPost]
        public ActionResult Update(Despesas despesas)
        {
            despesasrepositorio.Update(despesas);
            return RedirectToAction("Despesas");
        }
        [HttpGet]
        public ActionResult DeleteDespesa(int id)
        {
            despesasrepositorio.Delete(id);
            return RedirectToAction("Despesas");
        }
    }
}