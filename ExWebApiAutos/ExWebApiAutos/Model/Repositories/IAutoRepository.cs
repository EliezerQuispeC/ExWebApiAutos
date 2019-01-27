using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExWebApiAutos.Model.AutosDb;

namespace ExWebApiAutos.Model.Repositories
{
    public interface IAutoRepository : IRepository<Autos>
    {
        IQueryable<Autos> FilterAutos(int pageSize, int page);
    }
}
