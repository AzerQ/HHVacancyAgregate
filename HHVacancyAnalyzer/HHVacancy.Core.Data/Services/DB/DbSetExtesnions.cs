using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HHVacancy.Core.Data.Services.DB;

public static class DbSetExtesnions
{
    private static IEnumerable<TKeyType> GetExistingKeys<TKeyType>(IEnumerable<TKeyType> keys, )

     public static async Task AddOrUpdateRangeAsync<TEntity>(this DbSet<TEntity> dbSet, IEnumerable<TEntity> entities) where TEntity : class
    {
        var context = dbSet.GetService<ICurrentDbContext>().Context;
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        var primaryKey = entityType.FindPrimaryKey();
        var keyNames = primaryKey.Properties.Select(p => p.Name).ToArray();

        // Получаем идентификаторы сущностей
        var keyValuesList = entities.Select(e => GetPrimaryKey(e, keyNames)).ToList();

        // Проверяем, какие сущности уже существуют в базе данных
        var existingEntities = dbSet.Where(e => keyValuesList.Contains(GetPrimaryKey( e, keyNames))).ToList();
        var existingKeys = existingEntities.Select(e => GetPrimaryKey( e, keyNames)).ToList();

        foreach (var entity in entities)
        {
            var key = GetPrimaryKey( entity, keyNames);
            if (existingKeys.Contains(key))
            {
                // Обновляем существующую сущность
                var existingEntity = existingEntities.First(e => GetPrimaryKey(e, keyNames).SequenceEqual(key));
                context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                // Добавляем новую сущность
                await dbSet.AddAsync(entity);
            }
        }
    }

    private static object[] GetPrimaryKey(object entity, string[] keyNames)
    {
        var keyValues = keyNames.Select(k => entity.GetType().GetProperty(k).GetValue(entity)).ToArray();
        return keyValues;
    }
}
