using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFormGenerator.DomainClasses
{
    public class FieldValidation
    {
        public int Id { get; set; }
        public string Rule { get; set; }
        public virtual Field Field { get; set; }
    }
}
