using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioDePrestamo
    {
        private readonly SqlConnection _conexión;
        private readonly List<Prestamo> _prestamos = new List<Prestamo>();
        public RepositorioDePrestamo(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Prestamo prestamo)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into prestamo (Id,Nombre,CapIni,TasaInt,Tiempo,CapFin)
values (@Id, @Nombre, @CapitalInicial, @TasaInteres, @Tiempo, @CapitalFinal)";
                comando.Parameters.AddWithValue("@Id", prestamo.Identidad);
                comando.Parameters.AddWithValue("@Nombre", prestamo.Nombre);
                comando.Parameters.AddWithValue("@CapitalInicial", prestamo.CapitalInicial);
                comando.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                comando.Parameters.AddWithValue("@Tiempo", prestamo.Tiempo);
                comando.Parameters.AddWithValue("@CapitalFinal", prestamo.CapitalFinal);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Prestamo> ConsultarTodos()
        {
            SqlDataReader lectorDeDatos;
            List<Prestamo> prestamos = new List<Prestamo>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from prestamo ";
                lectorDeDatos = comando.ExecuteReader();
                if (lectorDeDatos.HasRows)
                {
                    while (lectorDeDatos.Read())
                    {
                        Prestamo prestamo = MapearDatosEnLector(lectorDeDatos);
                        prestamos.Add(prestamo);
                    }
                }
            }
            return prestamos;
        }

        private Prestamo MapearDatosEnLector(SqlDataReader lectorDeDatos)
        {
            if (!lectorDeDatos.HasRows) return null;
            Prestamo prestamo = new Prestamo();
            prestamo.Identidad = (string)lectorDeDatos["Id"];
            prestamo.Nombre = (string)lectorDeDatos["Nombre"];
            prestamo.CapitalInicial = (decimal)lectorDeDatos["CapIni"];
            prestamo.TasaInteres = (decimal)lectorDeDatos["TasaInt"];
            prestamo.Tiempo = (decimal)lectorDeDatos["Tiempo"];
            return prestamo;
        }
    }
}