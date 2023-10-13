using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IAuditTrailService
    {
        Task<IEnumerable<AuditTrail>> GetAllAuditTrailsAsync();
        Task<AuditTrail?> GetAuditTrailByIdAsync(int auditTrailId);
        Task<bool> AddAuditTrailAsync(AuditTrail auditTrail);
    }
}
