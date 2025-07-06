using System.Linq.Expressions;

namespace LibrarySystem.Data.Models.core
{
    public class ExtensionOrderAttribute
    {
        public string Attribute { get; set; }
        public string Direction { get; set; }
    }
    public class OrderBySpecs<TEntity, TId>
        where TEntity : Entity<TId>
    {

        public static OrderBySpecs<TEntity, TId> DefaultInstance = new OrderBySpecs<TEntity, TId>();
        public IQueryable<TEntity> Order(IQueryable<TEntity> source, List<ExtensionOrderAttribute> OrderBy)
        {
            if (OrderBy == null || OrderBy.Count == 0)
            {
                return source.OrderByDescending(x => x.Created);
            }


            IOrderedQueryable<TEntity> orderedQuery = null;
            foreach (var field in OrderBy)
            {

                var propertyName = field.Attribute;
                var property = typeof(TEntity).GetPropertyByNameInsensitive(propertyName);
                if (property == null) continue;

                var parameter = Expression.Parameter(typeof(TEntity));
                var propertyAccess = Expression.Property(parameter, property);
                var cast = Expression.Convert(propertyAccess, typeof(object));
                var propertySelector = Expression.Lambda<Func<TEntity, object>>(cast, parameter);

                if (field.Direction.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    orderedQuery = orderedQuery == null ?
                        source.OrderByDescending(propertySelector) : orderedQuery.ThenByDescending(propertySelector);
                }
                else
                {
                    orderedQuery = orderedQuery == null ?
                        source.OrderBy(propertySelector) : orderedQuery.ThenBy(propertySelector);
                }
            }

            return orderedQuery ?? source;
        }
    }
}

