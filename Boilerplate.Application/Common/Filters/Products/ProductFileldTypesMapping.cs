using System.Collections.ObjectModel;

namespace Boilerplate.Application.Common.Filters.Products
{

    public abstract class ProductFieldsConstants : FieldsConstants
    {
        public const string PRICE = nameof(PRICE);
        public const string SKU = nameof(SKU);
        public const string QUANTITY = nameof(QUANTITY);
    }
    public class ProductFileldTypesMapping : FileldTypesMapping
    {
        ICollection<FileldTypeMap> _fileldsMap = new Collection<FileldTypeMap>();

        public ProductFileldTypesMapping()
        {
            _fileldsMap.Add(new FileldType<string>(FieldsConstants.NAME, FieldTypes.Text));
            _fileldsMap.Add(new FileldType<decimal>(ProductFieldsConstants.PRICE, FieldTypes.Decimal));
            _fileldsMap.Add(new FileldType<DateTime>(FieldsConstants.CREATED, FieldTypes.Date));
        }

        public ICollection<FileldTypeMap> FieldsMap { get { return _fileldsMap; } }
    }
}
