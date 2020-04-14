using System;

namespace Entity
{
    public class Prestamo
    {
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public decimal CapitalInicial { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal Tiempo { get; set; }
        public decimal CapitalFinal { 
            get{
            return this.CapitalFinal * pow((1+this.TasaInteres),this.Tiempo);
        } 
        }
    }
}
