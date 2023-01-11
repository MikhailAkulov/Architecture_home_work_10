namespace ClinicService.Models
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА Добавить имплементацию для текущего репозитория
    /// </summary>
    public class Consultation
    {
        public int ConsultationId { get; set; }

        public int ClientId { get; set; }

        public int PetId { get; set; }

        public DateTime ConsultationDate { get; set; }

        public string Description { get; set; }
    }
}
