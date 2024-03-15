namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class ConsultOutputDTO
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdService { get; set; }
        public int IdDoctor { get; set; }
        public byte Convenio { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? IdentifiedGoogleCalendar { get; set; }

        public Patient Patient { get; set; }
        public ServiceEntity Service { get; set; }
        public Doctor Doctor { get; set; }
    }
}
