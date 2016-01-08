using System;
using System.Linq.Expressions;

namespace Swoop.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static LambdaExpression GetUnaryExpression<T>(this string propertyName)
        {
            var type = typeof(T);
            var pi = type.GetProperty(propertyName);
            var propType = pi.PropertyType;

            var param = Expression.Parameter(type, "x");
            Expression expr = Expression.Property(param, pi);
            Type delegateType = typeof(Func<,>).MakeGenericType(type, propType);
            return Expression.Lambda(delegateType, expr, param);
        }
    }
}
