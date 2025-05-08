using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class AnimalsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public DateTime? birthdate { get; set; }
        public string Sex { get; set; }
        public string OwnerDni { get; set; }
    }
}
