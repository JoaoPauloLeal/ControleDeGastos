using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.Core
{
    public class Gastos
    {
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigadório")]
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