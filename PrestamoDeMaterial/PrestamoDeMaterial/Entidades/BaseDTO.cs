using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamoDeMaterial.Entidades
{
    public abstract class BaseDTO
    {
        public string Id { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
