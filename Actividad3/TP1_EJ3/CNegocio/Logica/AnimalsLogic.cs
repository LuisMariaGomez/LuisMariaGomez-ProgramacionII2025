using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CNegocio.Logica.ILogica;
using CDatos.Repositorios.IRepo;
using Shared.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CNegocio.Logica
{
    public class AnimalsLogic : IAnimalsLogic
    {
        private readonly IAnimalsRepositorio _animalsRepositorio;
        public AnimalsLogic(IAnimalsRepositorio animalsRepositorio)
        {
            _animalsRepositorio = animalsRepositorio;
        }
        public AnimalsDTO ObtenerAnimal(int id)
        {
            var animal = _animalsRepositorio.ObtenerAnimal(id);
            return new AnimalsDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Race = animal.Race,
                birthdate = animal.birthdate,
                Sex = animal.Sex,
                OwnerDni = animal.OwnerDni
            };
        }
        public List<AnimalsDTO> ObtenerAnimales()
        {
            var animals = _animalsRepositorio.ObtenerAnimales();
            return animals.Select(animal => new AnimalsDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Race = animal.Race,
                birthdate = animal.birthdate,
                Sex = animal.Sex,
                OwnerDni = animal.OwnerDni
            }).ToList();
        }
        public void AgregarAnimal(AnimalsDTO animal)
        {
            // Validación: la fecha no puede ser futura
            if (animal.birthdate > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser una fecha futura.");
            var _animal = new Animals
            {
                Id = animal.Id,
                Name = animal.Name,
                Race = animal.Race,
                birthdate = animal.birthdate,
                Sex = animal.Sex,
                OwnerDni = animal.OwnerDni
            };
            _animalsRepositorio.AgregarAnimal(_animal);
        }
        public void ActualizarAnimal(AnimalsDTO animal)
        {
            var _animal = new Animals
            {
                Id = animal.Id,
                Name = animal.Name,
                Race = animal.Race,
                birthdate = animal.birthdate,
                Sex = animal.Sex,
                OwnerDni = animal.OwnerDni
            };
            _animalsRepositorio.ActualizarAnimal(_animal);

        }
        public void EliminarAnimal(int id)
        {
            _animalsRepositorio.EliminarAnimal(id);
        }
        public List<AnimalsDTO> ObtenerAnimalesPorDni(string dni)
        {
            var animals = _animalsRepositorio.ObtenerAnimalesPorDni(dni);
            return animals.Select(animal => new AnimalsDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Race = animal.Race,
                birthdate = animal.birthdate,
                Sex = animal.Sex,
                OwnerDni = animal.OwnerDni
            }).ToList();
        }
    }
}
