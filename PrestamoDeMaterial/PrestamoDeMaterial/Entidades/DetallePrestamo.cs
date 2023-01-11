namespace PrestamoDeMaterial.Entidades
{
    public class DetallePrestamo
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return $"{Cantidad} - {Descripcion}";
        }
    }
}