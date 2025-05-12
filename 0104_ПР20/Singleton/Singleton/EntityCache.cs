using System;
using System.Collections.Generic;
using System.Linq;

public sealed class EntityCache
{
    private static readonly Lazy<EntityCache> instance =
        new Lazy<EntityCache>(() => new EntityCache());
    private readonly Dictionary<Type, HashSet<object>> storage =
        new Dictionary<Type, HashSet<object>>();
    private readonly object lockObj = new object();

    public static EntityCache Instance => instance.Value;

    private EntityCache() { }

    public bool RegisterType(Type type)
    {
        lock (lockObj)
        {
            if (storage.ContainsKey(type)) return false;
            storage[type] = new HashSet<object>();
            return true;
        }
    }

    public bool AddEntity(object entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        lock (lockObj)
        {
            Type type = entity.GetType();
            if (!storage.ContainsKey(type)) return false;
            return storage[type].Add(entity);
        }
    }

    public bool ContainsType(Type type)
    {
        lock (lockObj)
        {
            return storage.ContainsKey(type);
        }
    }

    public bool ContainsEntity(object entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        lock (lockObj)
        {
            Type type = entity.GetType();
            return storage.ContainsKey(type) && storage[type].Contains(entity);
        }
    }

    public IEnumerable<object> GetEntities(Type type)
    {
        lock (lockObj)
        {
            return storage.ContainsKey(type)
                ? storage[type].ToList()
                : Enumerable.Empty<object>();
        }
    }

    public bool RemoveEntity(object entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        lock (lockObj)
        {
            Type type = entity.GetType();
            return storage.ContainsKey(type) && storage[type].Remove(entity);
        }
    }

    public bool RemoveType(Type type)
    {
        lock (lockObj)
        {
            return storage.Remove(type);
        }
    }
}