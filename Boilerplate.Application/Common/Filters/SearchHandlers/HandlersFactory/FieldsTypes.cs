using Boilerplate.Application.Common.Filters.Products;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.HandlersFactory
{
    internal static class FieldsTypes
    {
        internal static Dictionary<string, Type> FieldType { get; } = new Dictionary<string, Type>()
        {
            { FieldsConstants.NAME, typeof(string) },
            { FieldsConstants.DESCRIPTION, typeof(string) },
            { ProductFieldsConstants.SKU, typeof(string) },
            { ProductFieldsConstants.PRICE, typeof(decimal) },
            { ProductFieldsConstants.QUANTITY, typeof(int) },
            { FieldsConstants.CREATED, typeof(DateTime) }
        };
    }
}
