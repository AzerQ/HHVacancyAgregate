using Microsoft.EntityFrameworkCore;

namespace HHVacancy.Storage.Extensions;

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
