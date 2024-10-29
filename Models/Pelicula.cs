public class Pelicula
{
    public int ID_Pelicula { get; set; }
    public required string Título { get; set; }
    public required string Descripción { get; set; }
    public int Año_Estreno { get; set; }
    public int Duración { get; set; } // Duración en minutos
    public required string Imagen_URL { get; set; }
    public required string Trailer_URL { get; set; }
    public int ID_Género { get; set; } // FK

    public virtual required Genero Genero { get; set; } 
}