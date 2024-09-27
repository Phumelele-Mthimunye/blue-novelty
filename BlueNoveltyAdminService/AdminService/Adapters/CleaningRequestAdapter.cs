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
    public class CleaningRequestAdapter : ICleaningRequestAdapter
    {
        private readonly AppDbContext _context; 

        public CleaningRequestAdapter(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(DeleteDBRequest request)
        {
            var entity = _context.CleaningRequests.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }
        }

        public CleaningRequestDetailDTO Insert(CleaningRequestDTO request)
        {
            var entity = new CleaningRequest(request);
            _context.CleaningRequests.Add(entity);
            _context.SaveChanges();
            return _context.CleaningRequests
                .Where(x => x.Id == entity.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }

        public List<CleaningRequestDetailDTO> Read(CleaningRequestDetailDTO request)
        {
            return _context.CleaningRequests
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .ToList();
        }

        public CleaningRequestDetailDTO Update(CleaningRequestWithIdDTO request)
        {
            var entity = _context.CleaningRequests.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.MapUpdateValues(request);
                _context.SaveChanges();
            }
            return _context.CleaningRequests
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }
    }
}
