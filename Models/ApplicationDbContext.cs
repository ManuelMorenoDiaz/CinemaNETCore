using Microsoft.EntityFrameworkCore;

public class MediaDBContext : DbContext
{
    public MediaDBContext(DbContextOptions<MediaDBContext> options) : base(options)
    {
    }

    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Actor> Actores { get; set; }
    public DbSet<HistorialVisto> HistorialVistos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Episodio> Episodios { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Perfil> Perfiles { get; set; }
    public DbSet<ActorPelicula> ActorPeliculas { get; set; }
    public DbSet<ActorSerie> ActorSeries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configuración para la tabla Pelicula
    modelBuilder.Entity<Pelicula>()
        .HasKey(p => p.ID_Pelicula);

    modelBuilder.Entity<Pelicula>()
        .HasOne<Genero>(p => p.Genero)
        .WithMany()
        .HasForeignKey(p => p.ID_Género);

    // Configuración para la tabla Serie
    modelBuilder.Entity<Serie>()
        .HasKey(s => s.ID_Serie);

    modelBuilder.Entity<Serie>()
        .HasOne<Genero>(s => s.Genero)
        .WithMany()
        .HasForeignKey(s => s.ID_Género);

    // Configuración para la tabla Actor
    modelBuilder.Entity<Actor>()
        .HasKey(a => a.ID_Actor);

    // Relación muchos a muchos entre Actores y Películas
    modelBuilder.Entity<ActorPelicula>()
        .HasKey(ap => new { ap.ID_Actor, ap.ID_Pelicula });

    modelBuilder.Entity<ActorPelicula>()
        .HasOne(ap => ap.Actor)
        .WithMany(a => a.ActorPeliculas)
        .HasForeignKey(ap => ap.ID_Actor);

    modelBuilder.Entity<ActorPelicula>()
        .HasOne(ap => ap.Pelicula)
        .WithMany()
        .HasForeignKey(ap => ap.ID_Pelicula);

    // Relación muchos a muchos entre Actores y Series
    modelBuilder.Entity<ActorSerie>()
    .HasKey(ase => new { ase.ID_Actor, ase.ID_Serie });

    modelBuilder.Entity<ActorSerie>()
        .HasOne(ase => ase.Actor)
        .WithMany(ase => ase.ActorSeries)
        .HasForeignKey(ase => ase.ID_Actor);

    modelBuilder.Entity<ActorSerie>()
        .HasOne(ase => ase.Serie)
        .WithMany()
        .HasForeignKey(ase => ase.ID_Serie);

    // Configuración para la tabla HistorialVisto
    modelBuilder.Entity<HistorialVisto>()
        .HasKey(hv => hv.ID_Historial);

    modelBuilder.Entity<HistorialVisto>()
        .HasOne(hv => hv.Perfil)
        .WithMany()
        .HasForeignKey(hv => hv.ID_Perfil);
    
    modelBuilder.Entity<HistorialVisto>()
        .HasOne(hv => hv.Pelicula)
        .WithMany()
        .HasForeignKey(hv => hv.ID_Pelicula)
        .OnDelete(DeleteBehavior.SetNull); // Permitir que se elimine una película sin eliminar el historial

    modelBuilder.Entity<HistorialVisto>()
        .HasOne(hv => hv.Serie)
        .WithMany()
        .HasForeignKey(hv => hv.ID_Serie)
        .OnDelete(DeleteBehavior.SetNull); // Permitir que se elimine una serie sin eliminar el historial

    // Configuración para la tabla Episodio
    modelBuilder.Entity<Episodio>()
        .HasKey(e => e.ID_Episodio);

    modelBuilder.Entity<Episodio>()
        .HasOne(e => e.Serie)
        .WithMany() // Asumiendo que agregaste una colección de episodios en Serie
        .HasForeignKey(e => e.ID_Serie);
}
}