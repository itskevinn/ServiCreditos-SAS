using System;
using System.Collections.Generic;
using Datos;

using Entity;

namespace Logica
{
    public class ServicioDePrestamo
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioDePrestamo _repositorio;
        public ServicioDePrestamo(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            _repositorio = new RepositorioDePrestamo(_conexión);
        }

        public GuardarPrestamoResponse Guardar(Prestamo prestamo)
        {
            if (ValidarRegistro(prestamo.Identidad))
            {
                try
                {
                    _conexión.Abrir();
                    _repositorio.Guardar(prestamo);
                    _conexión.Cerrar();
                    return new GuardarPrestamoResponse(prestamo);
                }
                catch (Exception e)
                {
                    return new GuardarPrestamoResponse(e.Message);
                }
            }
            else return new GuardarPrestamoResponse("Un prestamo por persona!");
        }
        public bool ValidarRegistro(string idBuscar)
        {
            if (BuscarxId(idBuscar).Error)
            {
                return true;
            }
            return false;
        }

        public ConsultarPrestamosResponse ConsultarPrestamos()
        {
            try
            {
                _conexión.Abrir();
                List<Prestamo> prestamos = _repositorio.ConsultarTodos();
                _conexión.Cerrar();
                return new ConsultarPrestamosResponse(prestamos);
            }
            catch (Exception e)
            {
                return new ConsultarPrestamosResponse(e.Message);
            }
        }
        public BuscarxIdResponse BuscarxId(string idBuscar)
        {
            var respuesta = ConsultarPrestamos();
            foreach (var Prestamo in respuesta.Prestamos)
            {
                if (Prestamo.Identidad == idBuscar)
                {
                    return new BuscarxIdResponse(Prestamo);
                }
            }
            return new BuscarxIdResponse("No se encontró");
        }
        public class BuscarxIdResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Prestamo Prestamo { get; set; }
            public BuscarxIdResponse(Prestamo prestamo)
            {
                Error = false;
                Prestamo = prestamo;
            }
            public BuscarxIdResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
        public class GuardarPrestamoResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Prestamo Prestamo { get; set; }
            public GuardarPrestamoResponse(Prestamo prestamo)
            {
                Error = false;
                Prestamo = prestamo;
            }
            public GuardarPrestamoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
        public class ConsultarPrestamosResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Prestamo> Prestamos = new List<Prestamo>();
            public ConsultarPrestamosResponse(List<Prestamo> prestamo)
            {
                Error = false;
                Prestamos = prestamo;
            }
            public ConsultarPrestamosResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

    }
}