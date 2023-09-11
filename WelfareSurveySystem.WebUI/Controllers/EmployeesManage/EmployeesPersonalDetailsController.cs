using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WelfareSurveySystem.Data;
using WelfareSurveySystem.Domain.Business;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.WebUI.Controllers.EmployeesManage
{
    //[Authorize(Roles = "resercher")]

    public class EmployeesPersonalDetailsController : Controller
    {

        private IWelfareSurveySystemBusiness employeesManage;

        public WelfareSurveySystemDBContext Db { get; }

        public EmployeesPersonalDetailsController(IWelfareSurveySystemBusiness employeesManage, WelfareSurveySystemDBContext db)
        {
            this.employeesManage = employeesManage;
            Db = db;
        }

        public IActionResult List()
        {
            var empList = employeesManage.GetAllEmployees();
            return View(empList);
        }

        public IActionResult Index(string serviceNo = null)
        {
            Employee emp = null;
            //string message = "Employee not found...";
            if (serviceNo != null)
            {
                //TODO: add GetEmployeeByServiceNo() in Data and Domain Layer
                emp = employeesManage.GetAllEmployees().Where(e => e.ServiceNo.Trim() == serviceNo.Trim()).FirstOrDefault();
                //message = "";
                if (emp == null)
                {
                    TempData["Msg"] = "Employee not found, search again";
                }
            }



            return View(emp);
        }


        // www.sdfsdfsdfsdf.com/EmployeesPersonalDetails/Create
        //EmployeesPersonalDetails

        [HttpGet]
        public IActionResult CreatePersonalDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePersonalDetails(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            employee.SysDate = DateTime.Now;
            employeesManage.SaveEmployee(employee);
            TempData["SuccessMsg"] = $"Employee {employee.FullName} personal details created successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddParents(int empID)
        {
            //ViewBag.Employee = employee;
            //var emp = employeesManage.GetEmployee(id);

            ViewBag.EmployeeID = empID;  //to take same employeeID from create new employee view

            //We have to add in repository to get all parents based on employee ID List<Parent> GetParents(int empID);
            List<Parent> parents = Db.Parents.Where(p =>p.EmployeeID == empID).ToList();
            return View(parents);
        }


        [HttpPost]
        public IActionResult AddParents(Parent parent)
        {
            Employee associatedEmployee = employeesManage.GetEmployee(parent.EmployeeID);

            if (!ModelState.IsValid || associatedEmployee == null)
            {
                TempData["ErrorMsg"] = "Error submitting the form.";
                List<Parent> existingParents = employeesManage.GetAllParents();
                return View(existingParents);
            }

            // At this point, the form submission is valid and the associated data exists
            //parent.EmployeeID = empID; // Set the EmployeeID for the Parent

            employeesManage.SaveParent(parent.EmployeeID, parent); // Save parent data to the database

            ViewBag.Msg = parent.Name;

            return View("Index");
        }

        ///////////////////////////////
        [HttpGet]
        public IActionResult AddChildren(int empID)
        {
            //ViewBag.Employee = employee;
            //var emp = employeesManage.GetEmployee(id);

            ViewBag.EmployeeID = empID;  //to take same employeeID from create new employee view
            List<Children> children = employeesManage.GetChildren(empID); // this method

            return View(children);
        }


        [HttpPost]
        public IActionResult AddChildren(Children children)
        {
            Employee associatedEmployee = employeesManage.GetEmployee(children.EmployeeID);

            if (!ModelState.IsValid || associatedEmployee == null)
            {
                TempData["ErrorMsg"] = "Error submitting the form.";
                List<Children> existingChildren = employeesManage.GetChildren(children.EmployeeID);
                return View(existingChildren);
            }

            // At this point, the form submission is valid and the associated data exists
            //parent.EmployeeID = empID; // Set the EmployeeID for the Parent

            employeesManage.SaveChildren(children.EmployeeID, children); // Save parent data to the database

            ViewBag.Msg = children.Name;

            return View("Index");
        }
        //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        [HttpGet]
        public IActionResult AddSpouse(int empID)
        {
            //ViewBag.Employee = employee;
            //var emp = employeesManage.GetEmployee(id);

            ViewBag.EmployeeID = empID;  //to take same employeeID from create new employee view
            List<Spouse> spouse = employeesManage.GetSpouse(empID); // this method

            return View(spouse);
        }


        [HttpPost]
        public IActionResult AddSpouse(Spouse spouse)
        {
            Employee associatedEmployee = employeesManage.GetEmployee(spouse.EmployeeID);

            if (!ModelState.IsValid || associatedEmployee == null)
            {
                TempData["ErrorMsg"] = "Error submitting the form.";
                List<Spouse> existingSpouse = employeesManage.GetSpouse(spouse.EmployeeID);
                return View(existingSpouse);
            }

            // At this point, the form submission is valid and the associated data exists
            //parent.EmployeeID = empID; // Set the EmployeeID for the Parent

            employeesManage.SaveSpouse(spouse.EmployeeID, spouse); // Save parent data to the database

            ViewBag.Msg = spouse.Name;

            return View("Index");
        }
        //siblingggggggggggggggggggggggggg
        [HttpGet]
        public IActionResult AddSibling(int empID)
        {
            //ViewBag.Employee = employee;
            //var emp = employeesManage.GetEmployee(id);

            ViewBag.EmployeeID = empID;  //to take same employeeID from create new employee view
            List<Sibling> sibling = employeesManage.GetSibling(empID); // this method

            return View(sibling);
        }


        [HttpPost]
        public IActionResult AddSibling(Sibling sibling)
        {
            Employee associatedEmployee = employeesManage.GetEmployee(sibling.EmployeeID);

            if (!ModelState.IsValid || associatedEmployee == null)
            {
                TempData["ErrorMsg"] = "Error submitting the form.";
                List<Spouse> existingSpouse = employeesManage.GetSpouse(sibling.EmployeeID);
                return View(existingSpouse);
            }

            // At this point, the form submission is valid and the associated data exists
            //parent.EmployeeID = empID; // Set the EmployeeID for the Parent

            employeesManage.SaveSibling(sibling.EmployeeID, sibling); // Save parent data to the database

            ViewBag.Msg = sibling.Name;

            return View("Index");
        }

        [HttpGet]
        public IActionResult AddRealEstate(int empID)
        {
            ViewBag.EmployeeID = empID;  //to take same employeeID from create new employee view
            List<RealEstate> realEstates = employeesManage.GetAllRealEstate().Where(e => e.EmployeeID == empID).ToList(); // this method

            var realEstateTypes = employeesManage.GetRealEstateTypes(); // to fill dropdown

            // for dropdown values
            ViewBag.RealEstateTypes = from r in realEstateTypes
                                      select new SelectListItem { Text = r.RealEstateTypeName, Value = r.RealEstateTypeId.ToString() };


            return View(realEstates);
        }
        [HttpPost]
        public IActionResult AddRealEstate(RealEstate realEstate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            employeesManage.SaveRealEstate(realEstate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RealEstateEdit(int id)
        {
            // return a filled view
            RealEstate realEstate = employeesManage.GetAllRealEstate().Where(r => r.RealEstateId == id).FirstOrDefault();
            var realEstateTypes = employeesManage.GetRealEstateTypes(); // to fill dropdown

            // for dropdown values
            ViewBag.RealEstateTypes = from r in realEstateTypes
                                      select new SelectListItem { Text = r.RealEstateTypeName, Value = r.RealEstateTypeId.ToString() };

            return View(realEstate);
        }

        [HttpPost]
        public IActionResult RealEstateEdit(RealEstate realEstate)
        {
            if (!ModelState.IsValid)
                return View();

            employeesManage.EditRealEstate(0, 0, realEstate);//change this method
            //return RedirectToAction("AddRealEstate", realEstate.EmployeeID);
            return View("Index");
        }

        [HttpGet]
        public IActionResult RealEstateDelete(int id)
        {
            employeesManage.DeleteRealEstate(0, id); // change
            return View("Index");
        }


        //parent edit form
        [HttpGet]
        public IActionResult EditParents(int id)
        {
          
            var parentToEdit = employeesManage.GetParent(id);
            
            return View(parentToEdit);
        }

        [HttpPost]
        public IActionResult EditParents(Parent Parentedit)
        {
            

            employeesManage.EditParent(Parentedit);
            TempData["Msg"] = $"Parent ID {Parentedit.PersonId} updated...";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteParents(int id)
        {
           
            var parent = employeesManage.GetParent(id);
            return View(parent);

        }

        public IActionResult ConfirmDelete(int id)
        {
            employeesManage.DeleteParent(id);
            //var categories = manageCategory.GetAllCategories();
            //return View("Index", categories);


            TempData["Msg"] = $"The Parent ID {id} successfully deleted";
            return RedirectToAction("Index");
        }
        //Edit children
        [HttpGet]
        public IActionResult EditChildrens(int id)
        {
            
            var ChildrenToEdit = employeesManage.GetChildrens(id);
            return View(ChildrenToEdit);
        }

        [HttpPost]
        public IActionResult EditChildrens(Children Childrenedit)
        {
           

            employeesManage.EditChildren(Childrenedit);
            TempData["Msg"] = $"Children ID {Childrenedit.PersonId} updated...";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteChildren(int id)
        {

            var children = employeesManage.GetChildren(id);
            return View(children);

        }

        public IActionResult ConfirmDeleteChildren(int id)
        {
            employeesManage.DeleteChildren(id);
            //var categories = manageCategory.GetAllCategories();
            //return View("Index", categories);


            TempData["Msg"] = $"The Children ID {id} successfully deleted";
            return RedirectToAction("Index");
        }
        //Edit Spouse
        [HttpGet]
        public IActionResult EditSpouse(int id)
        {

            var SpouseToEdit = employeesManage.GetSpouses(id);
            return View(SpouseToEdit);
        }

        [HttpPost]
        public IActionResult EditSpouse(Spouse SpouseEdit)
        {


            employeesManage.EditSpouse(SpouseEdit);
            TempData["Msg"] = $"Children ID {SpouseEdit.PersonId} updated...";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSpouse(int id)
        {

            var spouse = employeesManage.GetSpouses(id);
            return View(spouse);

        }

        public IActionResult ConfirmDeleteSpouse(int id)
        {
            employeesManage.DeleteSpouse(id);
            //var categories = manageCategory.GetAllCategories();
            //return View("Index", categories);


            TempData["Msg"] = $"The Spouse ID {id} successfully deleted";
            return RedirectToAction("Index");
        }
        //Edit Sibling
        [HttpGet]
        public IActionResult EditSibling(int id)
        {

            var SiblingToEdit = employeesManage.GetSiblings(id);
            return View(SiblingToEdit);
        }

        [HttpPost]
        public IActionResult EditSibling(Sibling SiblingEdit)
        {


            employeesManage.EditSibling(SiblingEdit);
            TempData["Msg"] = $"Children ID {SiblingEdit.PersonId} updated...";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSibling(int id)
        {

            var sibling = employeesManage.GetSibling(id);
            return View(sibling);

        }

        public IActionResult ConfirmDeleteSibling(int id)
        {
            employeesManage.DeleteSibling(id);
            //var categories = manageCategory.GetAllCategories();
            //return View("Index", categories);


            TempData["Msg"] = $"The Sibling ID {id} successfully deleted";
            return RedirectToAction("Index");
        }
    }
}