using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleFormGenerator.DomainClasses
{
    public class Field
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "عنوان را وارد نمائید")]
        public string TitleEn { get; set; }
        public string TitleFa { get; set; }
        public FieldType FieldType { get; set; }

        public virtual Form Form { get; set; }
        public int FormId { get; set; }

        public virtual ICollection<FieldValidation> FieldValidations { get; set; }



    }

    public enum FieldType
    {
        Button,
        Checkbox,
        File,
        Hidden,
        Image,
        Password,
        Radio,
        Reset,
        Submit,
        Text
    }
}
