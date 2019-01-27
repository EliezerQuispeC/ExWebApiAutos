using System;
using System.Linq;
using ExWebApiAutos.Model.AutosDb;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<Autos> Autos => context.Autos;
        private AutosDbContext context;
        public EFAutoRepository(AutosDbContext ctx)
        {
            context = ctx;
        }
        public void SaveProject(Autos auto)
        {
            if (auto.AutoId == Guid.Empty)
            {
                auto.AutoId = Guid.NewGuid();
                context.Autos.Add(auto);
            }
            else
            {
                Autos dbEntry = context.Autos
                .FirstOrDefault(p => p.AutoId == auto.AutoId);
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
        public void DeleteAuto(Guid AutoID)
        {
            Autos dbEntry = context.Autos
                .FirstOrDefault(p => p.AutoId == AutoID);
            if(dbEntry != null)
            {
                context.Autos.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        Autos IAutoRepository.DeleteAuto(Guid AutoID)
        {
            throw new NotImplementedException();
        }
    }
}
