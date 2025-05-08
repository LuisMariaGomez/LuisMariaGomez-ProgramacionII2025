using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CDatos.Repositorios.IRepo;
using CNegocio.Logica.ILogica;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class OwnersLogic : IOwnersLogic
    {
        private readonly IOwnersRepositorio _ownersRepositorio;
        public OwnersLogic(IOwnersRepositorio ownersRepositorio)
        {
            _ownersRepositorio = ownersRepositorio;
        }
        public List<OwnersDTO> obtetenerOwners()
        {
            List<Owners> owners = _ownersRepositorio.ObtenerOwners();
            return owners.Select(owner => new OwnersDTO
            {
                Id = owner.Id,
                Dni = owner.Dni,
                Name = owner.Name,
                Surname = owner.Surname,
            }).ToList();
        }
        public OwnersDTO ObtenerOwner(int id)
        {
            Owners owner = _ownersRepositorio.ObtenerOwner(id);
            return new OwnersDTO
            {
                Id = owner.Id,
                Dni = owner.Dni,
                Name = owner.Name,
                Surname = owner.Surname,
            };
        }
        public OwnersDTO ObtenerOwnerPorDni(string dni)
        {
            Owners owner = _ownersRepositorio.ObtenerOwnerPorDni(dni);
            return new OwnersDTO
            {
                Id = owner.Id,
                Dni = owner.Dni,
                Name = owner.Name,
                Surname = owner.Surname,
            };
        }
        public List<OwnersDTO> ObtenerOwners()
        {
            List<Owners> owners = _ownersRepositorio.ObtenerOwners();
            return owners.Select(owner => new OwnersDTO
            {
                Id = owner.Id,
                Dni = owner.Dni,
                Name = owner.Name,
                Surname = owner.Surname,
            }).ToList();
        }
        public void AgregarOwner(OwnersDTO ownerDTO)
        {
            Owners owner = new Owners
            {
                Id = ownerDTO.Id,
                Dni = ownerDTO.Dni,
                Name = ownerDTO.Name,
                Surname = ownerDTO.Surname,
            };
            _ownersRepositorio.AgregarOwner(owner);
        }
        public void ActualizarOwner(OwnersDTO ownerDTO)
        {
            Owners owner = new Owners
            {
                Id = ownerDTO.Id,
                Dni = ownerDTO.Dni,
                Name = ownerDTO.Name,
                Surname = ownerDTO.Surname,
            };
            _ownersRepositorio.ActualizarOwner(owner);
        }
        public void EliminarOwner(int id)
        {
            _ownersRepositorio.EliminarOwner(id);
        }

    }
}
