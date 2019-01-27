using Application.DTOs;
using Application.IServices;
using ExWebApiAutos.Model.AutosDb;
using ExWebApiAutos.Model.Repositories;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class AutoService : IAutoService
    {
        IAutoRepository repository;
        public AutoService(IAutoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<AutoDTO> GetAll()
        {
            return Builders.GenericBuilder.builderListEntityDTO<AutoDTO, Autos>(repository.Items);
        }
        public void Insert(AutoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<Autos, AutoDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(AutoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<Autos, AutoDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
