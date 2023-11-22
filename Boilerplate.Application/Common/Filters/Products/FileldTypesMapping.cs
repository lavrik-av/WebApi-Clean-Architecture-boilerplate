namespace Boilerplate.Application.Common.Filters.Products
{
    public enum FieldTypes
    {
        Text = 1,
        Decimal = 2,
        Date = 3
    }

    public abstract class FieldsConstants
    {
        public const string NAME = nameof(NAME);
        public const string DESCRIPTION = nameof(DESCRIPTION);
        public const string CREATED = nameof(CREATED);
    }
    public abstract class FileldTypeMap
    {
        public string Field { get; set; } = string.Empty;
        public FieldTypes Type { get; set; }
        public virtual Type FieldType { get; set; } = typeof(string);
    }
    public class FileldType<T> : FileldTypeMap
    {
        public FileldType(string field, FieldTypes type)
        {
            Field = field;
            Type = type;
            FieldType = typeof(T);
        }
    }
    public abstract class FileldTypesMapping
    { }
}