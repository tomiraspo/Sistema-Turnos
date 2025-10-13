namespace Turnos.Domain.Entities;

public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public int ObraSocial { get; set; }
    public string Telefono { get; set; }
    public string Domicilio { get; set; }
}
