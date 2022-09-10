using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaverequest = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstAsync(q => q.Id == id);
            return leaverequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaverequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaverequests;
        }
    }
}
