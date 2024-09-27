using Domain.Data;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Entities;
using Domain.Models.Interfaces.Adapters;
using Microsoft.EntityFrameworkCore;
using SharedServices;
using System.Collections.Generic;
using System.Linq;

namespace AdminService.Adapters
{
    public class ServiceAdapter : IServiceAdapter
    {
        private readonly AppDbContext _context;

        public ServiceAdapter(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(DeleteDBRequest request)
        {
            var entity = _context.Services.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }
        }

        public ServiceDetailDTO Insert(ServiceDTO request)
        {
            var entity = new Service(request);
            _context.Services.Add(entity);
            _context.SaveChanges();
            return _context.Services
                .Where(x => x.Id == entity.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }

        public List<ServiceDetailDTO> Read(ServiceDetailDTO request)
        {
            return _context.Services
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .ToList();
        }

        public ServiceDetailDTO Update(ServiceWithIdDTO request)
        {
            var entity = _context.Services.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.MapUpdateValues(request);
                _context.SaveChanges();
            }
            return _context.Services
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }
    }
}
