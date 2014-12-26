using System.Collections.Generic;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    public interface IFormService
    {
        void AddForm(Form form);
        IList<Form> GetForms();

        Form GetForm(int formId);
    }
}
