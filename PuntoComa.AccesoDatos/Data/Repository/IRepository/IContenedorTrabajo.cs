using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoComa.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        // aqui se deben de ir agregando los diferentes repositorios
        ICategoriaRepository Categoria { get; }

        void save();
    }
}
