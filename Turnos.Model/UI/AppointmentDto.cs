namespace Turnos.Model.UI
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Motivo { get; set; }
        public string Profesional { get; set; }
        public string Paciente { get; set; }
    }
}