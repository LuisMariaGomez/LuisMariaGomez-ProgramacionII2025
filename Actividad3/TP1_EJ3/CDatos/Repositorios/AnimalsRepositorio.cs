using CDatos.Repositorios.IRepo;
using CDatos.Data;  
using Shared.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CDatos.Repositorios.Repositorios
{
    public class AnimalsRepositorio : IAnimalsRepositorio
    {
        private readonly DataContext _context;

        public AnimalsRepositorio(DataContext context)
        {
            _context = context;
        }
        public Animals ObtenerAnimal(int id)
        {
            return _context.Animals.FirstOrDefault(x => x.Id == id);
        }
        public List<Animals> ObtenerAnimales()
        {
            return _context.Animals.ToList();
        }
        public void AgregarAnimal(Animals animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }
        public void ActualizarAnimal(Animals animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }
        public void EliminarAnimal(int id)
        {
            var animal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }
        public List<Animals> ObtenerAnimalesPorDni(string dni)
        {
            return _context.Animals.Where(x => x.OwnerDni == dni).ToList();
        }

    }
}
