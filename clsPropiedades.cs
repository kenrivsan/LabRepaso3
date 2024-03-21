using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso3
{
    class clsPropiedades
    {
        int noCasa;
        int dpi;
        decimal cuota;

        public int NoCasa { get => noCasa; set => noCasa = value; }
        public int Dpi { get => dpi; set => dpi = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
    }
}
