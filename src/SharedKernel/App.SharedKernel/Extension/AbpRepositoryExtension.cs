using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.SharedKernel.Extension
{
    public static class AbpRepositoryExtension
    {
        public static IQueryable<T> GetAllAsNoTraking<T>(this IRepository<T> repository) where T : Entity
        {
            return repository.GetAll().AsNoTracking();
        }
    }
}
