using System.Collections.Generic;

namespace SimpleFormGenerator.DomainClasses
{
    public class Form
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Page { get; set; }
        public virtual ICollection<Field> Fields { get; set; }


    }
}
