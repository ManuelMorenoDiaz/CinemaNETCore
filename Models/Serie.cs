public class Serie
{
    public int ID_Serie { get; set; }
    
    public required string Título { get; set; }
    
    public required string Descripción { get; set; }
    
    public int Año_Estreno { get; set; }
    
    public int Duración_Episodio { get; set; } // Duración en minutos
    
    public required string Imagen_URL { get; set; }
    
    public required string Trailer_URL { get; set; }
    
    public int ID_Género { get; set; } // FK

    // Navegación hacia el género
    public virtual Genero Genero { get; set; } // No es necesario marcarlo como required aquí
}