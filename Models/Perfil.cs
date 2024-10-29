public class Perfil
{
    public int ID_Perfil { get; set; }
    public int ID_Usuario { get; set; } // FK
    public required string Nombre_Perfil { get; set; }
    public  string? Configuraciones { get; set; }
}