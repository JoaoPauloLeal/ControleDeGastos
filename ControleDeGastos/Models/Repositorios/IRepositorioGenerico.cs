using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        void Create(TEntity pEntity);
    }
}
