using CleanArchitecture.PracticalTest.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication
{
    public interface IContextDb
    {
        Task AddAsync(Paquete paquete);
        Task<Paquete?> GetByIdAsync(Guid id);
        Task UpdateAsync(Paquete paquete);
        IQueryable<Paquete> PaquetesQuery();

    }
}
