using Shared.Entities;

namespace CDatos.Repositorios.IRepo
{
    public interface IAtentionRepositorio
    {
        Attentions ObtenerAttention(int id);
        List<Attentions> ObtenerAttentions();
        void AgregarAttention(Attentions Attentions);
        void ActualizarAttention(Attentions Attentions);
        void EliminarAttention(int id);
    }
}
