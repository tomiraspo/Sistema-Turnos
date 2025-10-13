namespace Turnos.Model.UI;

public class ProfesionalDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public string Matricula { get; set; }
    public string Telefono { get; set; }
    public string Mail { get; set; }
    public string FullName => $"{Nombre} {Apellido}" ;
}