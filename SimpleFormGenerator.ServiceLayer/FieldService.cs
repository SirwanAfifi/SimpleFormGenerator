using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleFormGenerator.DataLayer.Context;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Field> _fields;

        public FieldService(IUnitOfWork uow)
        {
            _uow = uow;
            _fields = uow.Set<Field>();
        }

        public void AddField(Field field)
        {
            _fields.Add(field);
        }

        public IList<Field> GetFields()
        {
            return _fields.ToList();
        }

        public List<Field> GetFieldByFormId(int formId)
        {
            return _fields.Where(x => x.FormId == formId).ToList();
        }
    }
}
