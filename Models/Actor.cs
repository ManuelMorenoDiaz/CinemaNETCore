public class Actor
{
    public int ID_Actor { get; set; }
    public required string Nombre { get; set; }
    public DateTime? Fecha_Nacimiento { get; set; }
    public string? Biografía { get; set; }

    // Colección de películas en las que ha actuado
    public virtual ICollection<ActorPelicula> ActorPeliculas { get; set; } = new List<ActorPelicula>();
    
    // Colección de series en las que ha actuado
    public virtual ICollection<ActorSerie> ActorSeries { get; set; } = new List<ActorSerie>();
}

public class ActorPelicula 
{
    public int ID_Actor { get; set; }
    public int ID_Pelicula { get; set; }

    // Propiedades adicionales, como el rol del actor
    public string? Rol { get; set; }

    // Navegaciones hacia Actor y Película
    public virtual Actor Actor { get; set; } // Cambiado a virtual
    public virtual Pelicula Pelicula { get; set; } // Cambiado a virtual
}

public class ActorSerie 
{
    public int ID_Actor { get; set; }
    public int ID_Serie { get; set; }

    // Propiedades adicionales, como el rol del actor
    public string? Rol { get; set; }

    // Navegaciones hacia Actor y Serie
    public virtual Actor Actor { get; set; } // Cambiado a virtual
    public virtual Serie Serie { get; set; } // Cambiado a virtual
}