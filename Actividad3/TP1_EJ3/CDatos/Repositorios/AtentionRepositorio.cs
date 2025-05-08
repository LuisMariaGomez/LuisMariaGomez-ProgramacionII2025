using Shared.Entities;
using CDatos.Repositorios.IRepo;
using CDatos.Data;

namespace CDatos.Repositorios.Repositorios
{
    public class AttentionsRepositorio : IAtentionRepositorio
    {
        private readonly DataContext _context;

        public AttentionsRepositorio(DataContext context)
        {
            _context = context;
        }
        public Attentions ObtenerAttention(int id)
        {
            return _context.Attentions.FirstOrDefault(x => x.Id == id);
        }
        public List<Attentions> ObtenerAttentions()
        {
            return _context.Attentions.ToList();
        }
        public void AgregarAttention(Attentions Attentions)
        {
            _context.Attentions.Add(Attentions);
            _context.SaveChanges();
        }
        public void ActualizarAttention(Attentions Attentions)
        {
            _context.Attentions.Update(Attentions);
            _context.SaveChanges();
        }
        public void EliminarAttention(int id)
        {
            var Attentions = _context.Attentions.FirstOrDefault(x => x.Id == id);
            if (Attentions != null)
            {
                _context.Attentions.Remove(Attentions);
                _context.SaveChanges();
            }
        }
    }
}
