using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExWebApiAutos.Model.AutosDb;

namespace ExWebApiAutos.Model.Repositories
{
    public interface IAutoRepository
    {
        IQueryable<Autos> Autos { get; }
        void SaveProject(Autos auto);
        Autos DeleteAuto(Guid AutoID);
    }
}
