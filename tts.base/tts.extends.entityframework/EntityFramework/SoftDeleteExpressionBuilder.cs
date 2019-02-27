using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tts.extends.entityframework
{
    public static class SoftDeleteExpressionBuilder
    {
        public const string SoftDeleteFieldNameOfBaseEnity = nameof(BaseEntity.DeleteFlag);
        public const string PropertyMethodNameOfEF = nameof(EF.Property);

        public static LambdaExpression Build(IMutableEntityType entityType)
        {
            // 1. Add the IsDeleted property
            entityType.GetOrAddProperty(SoftDeleteFieldNameOfBaseEnity, typeof(string));

            // 2. Create the query filter

            var parameter = Expression.Parameter(entityType.ClrType);

            // EF.Property<bool>(post, "IsDeleted")
            var propertyMethodInfo = typeof(EF).GetMethod(PropertyMethodNameOfEF).MakeGenericMethod(typeof(string));
            var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(SoftDeleteFieldNameOfBaseEnity));

            // EF.Property<bool>(post, "IsDeleted") == false
            BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(string.Empty));

            // post => EF.Property<bool>(post, "IsDeleted") == false
            var lambda = Expression.Lambda(compareExpression, parameter);
            return lambda;
        }
    }
}
