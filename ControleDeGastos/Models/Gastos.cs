using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class Gastos
    {
        public int IdTipo { get; set; }
        public string Nome { get; set; }
        public Gastos()
        {

        }
        public Gastos(int pIdTipo, string pNome)
        {
            IdTipo = pIdTipo;
            Nome = pNome;
        }
    }
}