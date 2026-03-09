using CleanArchitecture.PracticalTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entidades
{
    public class Ruta: BaseDomainModel
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal DistanciaEnKm { get; set; }
        public decimal HorasEstimadas { get; set; }
    }
}
