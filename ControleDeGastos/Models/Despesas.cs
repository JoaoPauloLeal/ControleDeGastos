using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class Despesas
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }
        public string Local { get; set; }

        public Despesas()
        {

        }
        public Despesas(int pId, string pData, float pValor, int pTipo, string pLocal)
        {
            Id = pId;
            Data = pData.Replace(" 00:00:00","");
            Valor = pValor;
            Tipo = pTipo;
            Local = pLocal;
        }
    }
}