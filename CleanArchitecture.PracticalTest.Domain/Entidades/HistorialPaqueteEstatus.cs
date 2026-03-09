using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entidades
{
    public class HistorialPaqueteEstatus: BaseDomainModel
    {
        public EstatusPaquete Estatus { get; set; }
        public DateTime FechaDeCambioEstado { get; set; }
        public string Motivo { get; set; }
        public Guid PaqueteId { get; set; }
    }
}
