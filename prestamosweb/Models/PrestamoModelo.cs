using Entity;

public class PrestamoInputModel
{
    public string Identidad { get; set; }
    public string Nombre { get; set; }
    public decimal CapitalInicial { get; set; }
    public double TasaInteres { get; set; }
    public int Tiempo { get; set; }
}
public class PrestamoViewModel : PrestamoInputModel
{
    public PrestamoViewModel()
    {
    }
    public PrestamoViewModel(Prestamo prestamo)
    {
        Identidad = prestamo.Identidad;
        Nombre = prestamo.Nombre;
        CapitalInicial = prestamo.CapitalInicial;
        TasaInteres = prestamo.TasaInteres;
        Tiempo = prestamo.Tiempo;
        CapitalFinal = prestamo.CapitalFinal;
    }
    public decimal CapitalFinal { get; set; }
}