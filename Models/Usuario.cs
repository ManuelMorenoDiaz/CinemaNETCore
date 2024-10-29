public class Usuario
{
    public int ID_Usuario { get; set; }
    public required string Nombre { get; set; }
    public required string Email { get; set; }
    public required string Contraseña { get; set; }
    public DateTime Fecha_Creación { get; set; }
}