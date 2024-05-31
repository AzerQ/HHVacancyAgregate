using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HHVacancy.Core.Data.Services.DB;

public static class DbSetExtesnions
{
    public static async Task AddRangeIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, IEnumerable<TEnt> entities, Func<TEnt, TKey> keySelector) where TEnt : class
    {
        var existingKeys = dbSet.Select(keySelector).ToHashSet();
        var newEntities = entities.Where(e =>
        {
            var key = keySelector(e);
            return key != null && !existingKeys.Contains(key);
        });
        await dbSet.AddRangeAsync(newEntities);
    }

}
