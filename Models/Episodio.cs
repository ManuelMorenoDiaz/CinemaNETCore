public class Episodio
{
    public int ID_Episodio { get; set; }
    public int ID_Serie { get; set; } // FK
    public  required string Título_Episodio { get; set; }
    public int Número_Episodio { get; set; }
    public int Duración_Episodio { get; set;} // Duración en minutos

   public virtual Serie? Serie { get;} // Navegación a Serie
}