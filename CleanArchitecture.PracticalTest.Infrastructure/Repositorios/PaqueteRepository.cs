using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using CleanArchitecture.PracticalTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Repositorios
{
    public class PaqueteRepository : IContextDb
    {
        private readonly ContextDb _context;

        public PaqueteRepository(ContextDb context)
        {
            this._context = context;
        }
        public async Task AddAsync(Paquete paquete)
        {
            await _context.Paquetes.AddAsync(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task<Paquete?> GetByIdAsync(Guid id)
        {
            return await _context.Paquetes.Include(x => x.Historial).Include(x => x.Ruta).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Paquete> PaquetesQuery()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Paquete paquete)
        {
            //_context.Paquetes.Update(paquete);
            await _context.SaveChangesAsync();
        }
    }
}
