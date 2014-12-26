using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFormGenerator.DomainClasses
{
    public class Value
    {
        public int Id { get; set; }

        public string Val { get; set; }



        public virtual Field Field { get; set; }
        [ForeignKey("Field")]
        public int FieldId { get; set; }



        public virtual Form Form { get; set; }
        [ForeignKey("Form")]
        public int FormId { get; set; }
        
    }
}
