using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CNegocio.Logica.ILogica;
using CDatos.Repositorios.IRepo;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class AttentionsLogic : IAttentionsLogic
    {
        private readonly IAtentionRepositorio _atentionRepositorio;
        public AttentionsLogic(IAtentionRepositorio atentionRepositorio)
        {
            _atentionRepositorio = atentionRepositorio;
        }
        public AttentionsDTO ObtenerAtencion(int id)
        {
            var Attention = _atentionRepositorio.ObtenerAttention(id);
            return new AttentionsDTO
            {
                Id = Attention.Id,
                AnimalId = Attention.AnimalId,
                ReasonForConsultation = Attention.ReasonForConsultation,
                Treatment = Attention.Treatment,
                Medications = Attention.Medications,
                Date = Attention.Date
            };
        }
        public List<AttentionsDTO> ObtenerAtenciones()
        {
            var attentions = _atentionRepositorio.ObtenerAttentions();
            return attentions.Select(at => new AttentionsDTO
            {
                Id = at.Id,
                AnimalId = at.AnimalId,
                ReasonForConsultation = at.ReasonForConsultation,
                Treatment = at.Treatment,
                Medications = at.Medications,
                Date = at.Date
            }).ToList();
        }
        public void AgregarAtencion(AttentionsDTO attention)
        {
            // Validación: la fecha no puede ser futura
            if (attention.Date > DateTime.Now)
                throw new ArgumentException("La fecha de atencion no puede ser una fecha futura.");
            var _attention = new Attentions
            {
                Id = attention.Id,
                AnimalId = attention.AnimalId,
                ReasonForConsultation = attention.ReasonForConsultation,
                Treatment = attention.Treatment,
                Medications = attention.Medications,
                Date = attention.Date
            };
            _atentionRepositorio.AgregarAttention(_attention);
        }
        public void ActualizarAtencion(AttentionsDTO attention)
        {
            var _atention = new Attentions
            {
                Id = attention.Id,
                AnimalId = attention.AnimalId,
                ReasonForConsultation = attention.ReasonForConsultation,
                Treatment = attention.Treatment,
                Medications = attention.Medications,
                Date = attention.Date
            };
            _atentionRepositorio.ActualizarAttention(_atention);
        }
        public void EliminarAtencion(int id)
        {
            _atentionRepositorio.EliminarAttention(id);
        }

    }
}
