using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        private readonly IGenericRepository<AuditTrail> _auditTrailRepository;

        public AuditTrailService(IGenericRepository<AuditTrail> auditTrailRepository)
        {
            _auditTrailRepository = auditTrailRepository;
        }

        public async Task<IEnumerable<AuditTrail>> GetAllAuditTrailsAsync()
        {
            return await _auditTrailRepository.GetAllAsync();
        }

        public async Task<AuditTrail?> GetAuditTrailByIdAsync(int auditTrailId)
        {
            return await _auditTrailRepository.GetByIdAsync(auditTrailId);
        }

        public async Task<bool> AddAuditTrailAsync(AuditTrail auditTrail)
        {
            await _auditTrailRepository.AddAsync(auditTrail);
            return await _auditTrailRepository.SaveAllAsync();
        }
    }
}
