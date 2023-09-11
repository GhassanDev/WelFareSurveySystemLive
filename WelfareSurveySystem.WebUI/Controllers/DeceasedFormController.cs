using Microsoft.AspNetCore.Mvc;
using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.Domain.Entities;
using WelfareSurveySystem.WebUI.Models;

namespace WelfareSurveySystem.WebUI.Controllers
{
    public class DeceasedFormController : Controller
    {

        private readonly IDeceasedRepository deceasedRepository;
        private readonly IEmployeeRepository employeeRepo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DeceasedFormController(IDeceasedRepository deceasedRepository, IEmployeeRepository employeeRepo, IWebHostEnvironment hostingEnvironment)
        {
            this.deceasedRepository = deceasedRepository;
            this.employeeRepo = employeeRepo;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult VerifyServiceNumber(string serviceNo)
        {
            // TODO: add GetEmployeeByServiceNo(string serviceNo) in business and data layer
            Employee emp = employeeRepo.GetAllEmployees().Where(e => e.ServiceNo == serviceNo).FirstOrDefault();
            return Json(emp.FullName);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TaskRequestViewModel());
        }
        [HttpPost]
        public IActionResult Create(TaskRequestViewModel taskRequestViewModel)
        {

            if (ModelState.IsValid)
            {
                string fromserviceNo = User.Identity.Name;
                // Retrieve the employee by ServiceNo from the repository
                var employee = deceasedRepository.GetDeceasedByServiceNo(taskRequestViewModel.ServiceNo);

                // check and fix the below logic
                //if (employee != null && employee.IsDeceased == true)
                //{
                //    ModelState.AddModelError("ServiceNo", "Employee is deceased.");
                //    return View(taskRequestViewModel);
                //}



                //=====================================
                // Handle file upload
                //if (taskRequestViewModel.UploadFile != null && taskRequestViewModel.UploadFile.Length > 0)
                if (taskRequestViewModel.Uploads.Any())
                {
                    // Process the uploaded file
                    // Here, you can save the file to a location, generate a unique filename, etc.

                    // Example: Saving the uploaded file to a specific folder
                    foreach (var file in taskRequestViewModel.Uploads)
                    {


                        var fileName = Path.GetFileName(file.FileName);
                        var fileNameWithServiceNo = taskRequestViewModel.ServiceNo + "-" + fileName;
                        string uniqueFileName = GetUniqueFileName(fileNameWithServiceNo);
                        //uniqueFileName += taskRequestViewModel.ServiceNo + uniqueFileName;
                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            //taskRequestViewModel.UploadFile.CopyTo(stream);
                            file.CopyTo(stream);
                        }

                        // Save the file path in the TaskRequestViewModel
                        //taskRequestViewModel.UploadFilePath = filePath;
                        taskRequestViewModel.Attachments.Add(new Document { DocumentPath = fileName, DocumentName = fileName });
                    }
                }
                //EndOFFileUpload=============================

                // Save the task request
                // ...

                TaskRequest taskRequest = new TaskRequest
                {
                    Branch = taskRequestViewModel.Branch,
                    DateRequested = DateTime.Now,
                    /*FromServiceNo = taskRequestViewModel.FromServiceNo,*/  // get the service number from user login id
                    FromServiceNo = fromserviceNo, // get the service number from user login id
                    //UploadFilePath = taskRequestViewModel.UploadFilePath,
                    WelfareForm = new DeceasedForm
                    {
                        DateOfDeceased = taskRequestViewModel.DateOfDeceased,
                        ReasonOfDeceased = taskRequestViewModel.ReasonOfDeceased,
                        ServiceNo = taskRequestViewModel.ServiceNo,
                        FormName = "Deceased Form"
                    },
                    Attachments = taskRequestViewModel.Attachments,
                    //Attachments = new List<Document>
                    //{
                    //    new Document
                    //    {
                    //        DocumentName = "fill the document type",
                    //        DocumentPath = taskRequestViewModel.UploadFilePath
                    //    }
                    //},

                };

                // save
                deceasedRepository.SaveDeceased(taskRequest);

                // set employe deceased to true
                Employee emp = employeeRepo.GetAllEmployees().Where(e => e.ServiceNo == taskRequestViewModel.ServiceNo).FirstOrDefault();
                emp.IsDeceased = true;
                employeeRepo.EditEmployee(emp.EmployeeID, emp);

                //return RedirectToAction("Index");
            }

            //return View(taskRequestViewModel);
            TempData["Msg"] = $"Request for Deceased [{taskRequestViewModel.ServiceNo}] Sent Successfully to Branch {taskRequestViewModel.Branch}";
            return RedirectToAction("Index", "Home");
            // validate
            // create TaskRequest object and copy from taskRequestViewModel
            // code file upload and save document
            // fill the remaining properties
            // design and implement domain layer and data layer code
            // save form data
            // return view



            //throw new NotImplementedException();
        }



        private static string GetUniqueFileName(string fileName)
        {

            string uniqueName = Path.GetRandomFileName();
            uniqueName = Path.GetFileNameWithoutExtension(uniqueName);
            string uniqueFileName = uniqueName + "-" + fileName;
            return uniqueFileName;
        }
    }
}
