using ControleDeGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeGastos.Controllers
{
    public class HomeController : Controller
    {
        DespesasRepositorio despesasrepositorio = new DespesasRepositorio();
        // GET: Home
        public ActionResult Index()
        {
            var despesas = despesasrepositorio.getSete();
            return View(despesas);
        }
    }
}