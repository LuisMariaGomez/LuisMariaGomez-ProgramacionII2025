using Shared.Entities;
namespace CDatos.Repositorios.IRepo
{
    public interface IAnimalsRepositorio
    {
        Animals ObtenerAnimal(int id);
        List<Animals> ObtenerAnimales();
        void AgregarAnimal(Animals animal);
        void ActualizarAnimal(Animals animal);
        void EliminarAnimal(int id);
        List<Animals> ObtenerAnimalesPorDni(string dni);
    }
}
