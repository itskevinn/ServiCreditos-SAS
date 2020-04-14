using System;

namespace Entity
{
    public class Prestamo
    {
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public decimal CapitalInicial { get; set; }
        public double TasaInteres { get; set; }
        public int Tiempo { get; set; }
        public decimal CapitalFinal { get; set; }  
        public void CalcularValorFinal(){
             TasaInteres = (TasaInteres / 100);                
                CapitalFinal = (CapitalInicial*(decimal)Math.Pow((1+TasaInteres),Tiempo));
        }
        public void CalcularMeses()
        {
            Tiempo = Tiempo * 12;            
        }
    }
}
