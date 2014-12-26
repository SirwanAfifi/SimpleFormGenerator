using System.Collections.Generic;
using System.Web.Mvc;
using SimpleFormGenerator.DataLayer.Context;
using SimpleFormGenerator.DomainClasses;
using SimpleFormGenerator.ServiceLayer;

namespace SimpleFormGenerator.UI.Controllers
{
    public class DynamicFormController : Controller
    {
        readonly IFormService _formService;
        readonly IFieldService _fieldService;
        readonly IValueService _valueService;
        readonly IUnitOfWork _uow;

        public DynamicFormController(IFormService formService, IUnitOfWork uow, IFieldService fieldService, IValueService valueService)
        {
            _formService = formService;
            _uow = uow;
            _fieldService = fieldService;
            _valueService = valueService;
        }

        public ActionResult Index()
        {
            var forms = _formService.GetForms();
            return View(forms);
        }

        public ActionResult CreateField()
        {
            ViewBag.FormList = new SelectList(_formService.GetForms(), "Id", "Title");
            ViewBag.FormTitle = "ایجاد فیلد";
            return View();
        }
        [HttpPost]
        public ActionResult CreateField(Field field)
        {
            if (ModelState.IsValid)
            {
                _fieldService.AddField(field);
                _uow.SaveAllChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateForm()
        {
            ViewBag.FormTitle = "ایجاد یک فرم جدید";
            return View();
        }
        [HttpPost]
        public ActionResult CreateForm(Form form)
        {
            if (ModelState.IsValid)
            {
                _formService.AddForm(form);
                _uow.SaveAllChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShowForm(int id)
        {
            var field = _fieldService.GetFieldByFormId(id);
            ViewBag.FormTitle = _formService.GetForm(id).Title;
            ViewBag.FormId = id;
            return View(field);
        }

        [HttpPost]
        public ActionResult ShowForm(IEnumerable<Field> values)
        {
            if (!ModelState.IsValid) return View(values);
            foreach (var value in values)
            {
                _valueService.AddValue(new Value { Val = value.TitleEn, FormId = value.FormId, FieldId = value.Id });
                _uow.SaveAllChanges();
            }
            return View(values);
        }
    }
}