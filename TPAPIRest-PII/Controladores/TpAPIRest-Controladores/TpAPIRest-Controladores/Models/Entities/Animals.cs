namespace TpAPIRest_Controladores.Models.Entities
{
    public class Animals
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public DateTime? birthdate { get; set; }
        public string Sex { get; set; }
        public string OwnerDni { get; set; }
    }
}
