public class HistorialVisto
{
    public int ID_Historial { get; set; }
    public int ID_Perfil { get; set; } // FK
    public int? ID_Pelicula { get; set; } // FK, puede ser nulo si es serie
    public int? ID_Serie { get; set; } // FK, puede ser nulo si es película
    public DateTime Fecha_Visto { get; set; }

    //     public virtual required Perfil Perfil { get; set;} // Navegación a Perfil
    //    public virtual required Pelicula Pelicula { get; set;} // Navegación a Película
    //    public virtual required Serie Serie { get; set;} // Navegación a Serie
}