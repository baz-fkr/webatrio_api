﻿using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public interface IJobRepository : IBaseRepository<JobEntity>
    {
        Task<List<JobEntity>> GetAllJobsForAPerson(Guid personId);
    }
}
