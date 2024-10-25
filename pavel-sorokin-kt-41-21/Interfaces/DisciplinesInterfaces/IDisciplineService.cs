﻿using Microsoft.EntityFrameworkCore;
using pavel_sorokin_kt_41_21.Database;
using pavel_sorokin_kt_41_21.Filters.DisciplineFilters;
using pavel_sorokin_kt_41_21.Models;

namespace pavel_sorokin_kt_41_21.Interfaces.DisciplinesInterfaces
{
    public interface IDisciplineService
    {
        public Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken);
     
        public Task<Discipline[]> GetDisciplinesIsDeletedAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken);
    }

    public class DisciplineService : IDisciplineService
    {
        private readonly StudentDbContext _dbContext;
        public DisciplineService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = _dbContext.Set<Discipline>().Where(w => w.Direction == filter.Direction).ToArrayAsync(cancellationToken);

            return disciplines;
        }

        public Task<Discipline[]> GetDisciplinesIsDeletedAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = _dbContext.Set<Discipline>().Where(w => w.IsDeleted == filter.IsDeleted).ToArrayAsync(cancellationToken);

            return disciplines;
        }
    }
}