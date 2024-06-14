using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unidad_1_practica_pasteleria
{
    public class Pan
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal TotalPorPan { get; set; }
        public int Disponibilidad {  get; set; }
        public int CantidadVenta {  get; set; }
        public string? Imagen {  get; set; }
        
    }
}
