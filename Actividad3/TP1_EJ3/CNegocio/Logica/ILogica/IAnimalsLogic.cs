using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;


namespace CNegocio.Logica.ILogica
{
    public interface IAnimalsLogic
    {
        AnimalsDTO ObtenerAnimal(int id);
        List<AnimalsDTO> ObtenerAnimales();
        void AgregarAnimal(AnimalsDTO animal);
        void ActualizarAnimal(AnimalsDTO animal);
        void EliminarAnimal(int id);
    }
}
