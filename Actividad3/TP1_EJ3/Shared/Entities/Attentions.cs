using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Attentions
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string ReasonForConsultation { get; set; }//
        public string Treatment { get; set; }//
        public string Medications { get; set; }//
        public DateTime Date { get; set; }
    }
}
