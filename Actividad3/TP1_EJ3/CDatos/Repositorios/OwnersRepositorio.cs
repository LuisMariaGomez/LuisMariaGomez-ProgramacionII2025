using Shared.Entities;
using CDatos.Data;
using CDatos.Repositorios.IRepo;


namespace CDatos.Repositorios.Repositorios
{
    public class OwnersRepositorio : IOwnersRepositorio
    {
        private readonly DataContext _context;

        public OwnersRepositorio(DataContext context)
        {
            _context = context;
        }
        public Owners ObtenerOwner(int id)
        {
            return _context.Owners.FirstOrDefault(x => x.Id == id);
        }
        public Owners ObtenerOwnerPorDni(string dni)
        {
            return _context.Owners.FirstOrDefault(x => x.Dni == dni);
        }
        public List<Owners> ObtenerOwners()
        {
            return _context.Owners.ToList();
        }
        public void AgregarOwner(Owners owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }
        public void ActualizarOwner(Owners owner)
        {
            _context.Owners.Update(owner);
            _context.SaveChanges();
        }
        public void EliminarOwner(int id)
        {
            var owner = _context.Owners.FirstOrDefault(x => x.Id == id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }
    }
}
