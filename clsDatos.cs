using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso3
{
    class clsDatos
    {
        string nombre;
        string apellidos;
        int numero;
        decimal cuota;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Numero { get => numero; set => numero = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
    }
}
