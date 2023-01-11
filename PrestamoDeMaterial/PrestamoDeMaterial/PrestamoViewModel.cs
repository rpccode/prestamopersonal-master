using PrestamoDeMaterial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamoDeMaterial
{
    public class PrestamoViewModel
    {
        public PrestamoViewModel()
        {

        }   
        public PrestamoViewModel(Prestamo prestamo)
        {
            Prestamo = prestamo;
            Detalle = new DetallePrestamo();
        }
        public Prestamo Prestamo { get; set; }
        public DetallePrestamo Detalle { get; set; }
    }
}
