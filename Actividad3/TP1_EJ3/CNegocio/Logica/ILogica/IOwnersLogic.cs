using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IOwnersLogic
    {
        OwnersDTO ObtenerOwner(int id);
        List<OwnersDTO> ObtenerOwners();
        void AgregarOwner(OwnersDTO ownerDTO);
        void ActualizarOwner(OwnersDTO ownerDTO);
        void EliminarOwner(int id);
        OwnersDTO ObtenerOwnerPorDni(string dni);
    }
}
