public class Pelicula
{
    public int ID_Pelicula { get; set; }
    public required string Título { get; set; }
    public required string Descripción { get; set; }
    public int Año_Estreno { get; set; }
    public int Duración { get; set; }
    public required string Imagen_URL { get; set; }
    public string? Trailer_URL { get; set; }
    public int ID_Género { get; set; } // Esta es la clave foránea

}