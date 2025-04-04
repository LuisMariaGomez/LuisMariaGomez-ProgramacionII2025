namespace TpAPIRest_Controladores.Models.DTOs
{
    public class AttentionsDTO
    {
        public long Id { get; set; }
        public int AnimalId { get; set; }
        public string ReasonForConsultation { get; set; }
        public string Treatment { get; set; }
        public string Medications { get; set; }
        public DateTime Date { get; set; }
    }
}
