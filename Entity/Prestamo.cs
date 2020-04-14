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
        public decimal CapitalFinal
        {
            get
            {
                decimal tasaInteres = 0;
                tasaInteres = (this.TasaInteres / 100);
                return this.CapitalFinal * Decimal.Parse(Math.Pow((1 + Double.Parse(tasaInteres + "m")), Double.Parse(this.Tiempo + "M")) + "m");
            }
        }
        public void CalcularMeses()
        {
            this.Tiempo = this.Tiempo * 12;            
        }
    }
}
