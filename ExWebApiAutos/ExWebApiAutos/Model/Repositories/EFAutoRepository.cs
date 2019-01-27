using System;
using System.Linq;
using ExWebApiAutos.Model.AutosDb;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<Autos> Items => context.Autos;
        private AutosDbContext context;
        public EFAutoRepository(AutosDbContext ctx)
        {
            context = ctx;
        }
        public void Save(Autos auto)
        {
            if (auto.Id == Guid.Empty)
            {
                auto.Id = Guid.NewGuid();
                context.Autos.Add(auto);
            }
            else
            {
                Autos dbEntry = context.Autos
                .FirstOrDefault(p => p.Id == auto.Id);
                if (dbEntry != null)
                {
                    dbEntry.Color = auto.Color;
                    dbEntry.AnioFab = auto.AnioFab;
                    dbEntry.NroPlaca = auto.NroPlaca;
                    dbEntry.NroAsientos = auto.NroAsientos;
                    dbEntry.EsMeca = auto.EsMeca;
                    dbEntry.EsFull = auto.EsFull;
                    dbEntry.Marca = auto.Marca;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid AutoID)
        {
            Autos dbEntry = context.Autos
                .FirstOrDefault(p => p.Id == AutoID);
            if(dbEntry != null)
            {
                context.Autos.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public IQueryable<Autos> FilterAutos(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }
    }
}
