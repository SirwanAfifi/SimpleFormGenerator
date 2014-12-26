using System.Collections.Generic;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    public interface IValueService
    {
        void AddValue(Value value);
        IList<Value> GetValues();
    }

}
