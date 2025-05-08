using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;


namespace CNegocio.Logica.ILogica
{
    public interface IAttentionsLogic
    {
        AttentionsDTO ObtenerAtencion(int id);
        List<AttentionsDTO> ObtenerAtenciones();
        void AgregarAtencion(AttentionsDTO attention);
        void ActualizarAtencion(AttentionsDTO attention);
        void EliminarAtencion(int id);
    }
}
