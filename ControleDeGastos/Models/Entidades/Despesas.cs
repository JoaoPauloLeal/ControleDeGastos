using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class Despesas
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }


        public decimal Valor { get; set; }

        public string Local { get; set; }

        //public int Tipo { get; set; }
        public Gastos gastos { get; set; }

        public Despesas()
        {

        }
        public Despesas(int pId, DateTime pData, decimal pValor, Gastos pgastos, string pLocal)
        {
            Id = pId;
            Data = pData.Date;
            Valor = pValor;
            gastos = pgastos;
            Local = pLocal;
        }
    }
}