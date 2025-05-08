using Shared.Entities;

namespace CDatos.Repositorios.IRepo
{
    public interface IOwnersRepositorio
    {
        Owners ObtenerOwner(int id);
        List<Owners> ObtenerOwners();
        void AgregarOwner(Owners owner);
        void ActualizarOwner(Owners owner);
        void EliminarOwner(int id);
        Owners ObtenerOwnerPorDni(string dni);
    }
}
