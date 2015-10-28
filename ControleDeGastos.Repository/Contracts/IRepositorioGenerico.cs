using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeGastos.Repository.Contracts
{
    interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        void Create(TEntity pEntity);
        void Update(TEntity pEntity);
        void Delete(int pId);
        IEnumerable<TEntity> getAll();
        TEntity getOne(int pId);
    }
}
