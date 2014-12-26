using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleFormGenerator.DataLayer.Context;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    public class FormService : IFormService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Form> _form;

        public FormService(IUnitOfWork uow)
        {
            _uow = uow;
            _form = _uow.Set<Form>();
        }

        public void AddForm(Form form)
        {
            _form.Add(form);
        }

        public IList<Form> GetForms()
        {
            return _form.ToList();
        }

        public Form GetForm(int formId)
        {
            return _form.Find(formId);
        }
    }
}
