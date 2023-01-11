using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestamoDeMaterial.Entidades
{
    public class Prestamo : BaseDTO
    {
        public Prestamo()
        {
            Detalle = new List<DetallePrestamo>();
        }
        public DateTime FechaHoraPrestamo { get; set; }
        public DateTime RetornoEstimado { get; set; }
        public string Matricula { get; set; }
        public string NombreAlumno { get; set; }
        public List<DetallePrestamo> Detalle { get; set; }
        public string Notas { get; set; }

        public bool Entregado { get; set; }

        public bool ContieneMaterial(string material)
        {
            foreach (var item in Detalle)
            {
                if (item.Descripcion.ToLower().Contains(material.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public int CantidadDeElementos
        {
            get
            {
                return Detalle.Sum(e => e.Cantidad);
            }
        }
        public bool Atrazado
        {
            get
            {
                return RetornoEstimado < DateTime.Now;
            }
        }

        public string Estado
        {
            get
            {
                if (Entregado)
                {
                    return "Entregado";
                }
                if (Atrazado)
                {
                    return "Atrazado";
                }
                return "Prestado";
            }
        }

        
    }
}
