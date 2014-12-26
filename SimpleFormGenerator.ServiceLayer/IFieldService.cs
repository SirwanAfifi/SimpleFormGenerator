using System.Collections.Generic;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    public interface IFieldService
    {
        void AddField(Field field);
        IList<Field> GetFields();

        List<Field> GetFieldByFormId(int formId);
    }
}
