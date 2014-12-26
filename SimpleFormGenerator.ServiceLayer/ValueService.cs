using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleFormGenerator.DataLayer.Context;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.ServiceLayer
{
    

    public class ValueService : IValueService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Value> _values;

        public ValueService(IUnitOfWork uow)
        {
            _uow = uow;
            _values = _uow.Set<Value>();
        }
       
        public void AddValue(Value value)
        {
            _values.Add(value);
        }

        public IList<Value> GetValues()
        {
            return _values.ToList();
        }

    }
}
