using Microsoft.AspNetCore.Mvc;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.WebUI.Components
{
    public class PersonDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Person person)
        {
            return View(person);
        }
    }
}
