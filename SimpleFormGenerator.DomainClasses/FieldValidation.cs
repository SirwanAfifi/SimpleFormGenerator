namespace SimpleFormGenerator.DomainClasses
{
    public class FieldValidation
    {
        public int Id { get; set; }
        public string Rule { get; set; }
        public virtual Field Field { get; set; }
    }
}