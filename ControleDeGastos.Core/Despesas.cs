using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.Core
{
    public class Despesas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo data é obrigadório")]
        public DateTime Data { get; set; }

        [Range(0.5, 50000, ErrorMessage = "O campo valor é obrigadório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo local é obrigadório")]
        public string Local { get; set; }

        
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