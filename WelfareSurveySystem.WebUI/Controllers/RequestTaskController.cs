using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WelfareSurveySystem.Data;
using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.Domain.Entities;
using WelfareSurveySystem.WebUI.Models;

namespace WelfareSurveySystem.WebUI.Controllers
{
    [Authorize(Roles = "researcher,manager,requester")]
    public class RequestTaskController : Controller
    {
        //comment
        private ITaskRequestRepository taskRequestRepository;
        private readonly IEmployeeRepository empRepo;
        private readonly WelfareSurveySystemDBContext db;
        public RequestTaskController(WelfareSurveySystemDBContext db, ITaskRequestRepository taskRequestRepository, IEmployeeRepository empRepo)
        {

            //return View();
            this.taskRequestRepository = taskRequestRepository;
            this.empRepo = empRepo;
            this.db = db;
        }
        //[Authorize(Roles = "resercher")]
        public IActionResult MyTasks()
        {
            // TODO:
            // get the current user login id
            // get the service number from login id

            // Data Layer
            // Add repository for TaskRequest

            // get the current login employee branch
            // get all the tasks for that branch
            // create MyTasksViewModel and fill into this
            // return that MyTasksViewModel to view


            string serviceNo = User.Identity.Name;
            // get the branch from service no
            string currentUserBranch = empRepo.GetAllEmployees().Where(e => e.ServiceNo == serviceNo).FirstOrDefault()?.Branch;


            List<TaskRequest> tasks = taskRequestRepository.GetAllTaskByBranchID(currentUserBranch);

            if (User.IsInRole("manager"))
            {
                tasks = tasks.Where(t => t.TaskStatus.ResearcherStatus == "Submitted").ToList();
            }

            //var formname = tasks

            // convert TaskRequest Domain Model to RequestTaskViewModel
            var tasksVM = from t in tasks
                          select new RequestTaskViewModel
                          {
                              FormName = t.WelfareForm.FormName,
                              FromServiceNo = t.FromServiceNo,
                              ServiceNo = t.WelfareForm.ServiceNo,
                              TaskRequestID = t.TaskRequestID,
                              ResearcherStatus = t.TaskStatus.ResearcherStatus,
                              ManagerStatus = t.TaskStatus.ManagerStatus,
                              TopManagerStatus = t.TaskStatus.TopManagerStatus,
                              Attachments = t.Attachments

                          };

            ViewBag.Branch = currentUserBranch;
            return View(tasksVM.ToList());
        }

        [HttpPost]
        public IActionResult SubmitMyTasks(List<int> personIdList, int taskreqid)
        {

            //var childs = db.Childrens.ToList();
            //var spouses = db.Spouses.ToList();
            //var siblings = db.Siblings.ToList();
            //var parents = db.Parents.ToList();
            // update the IsEligibleToSharePensionAmount with true
            string formattedIds = string.Join(",", personIdList);

            string sqlQuery = $"UPDATE childrens SET [IsEligibleToSharePensionAmount] = 'true' WHERE [PersonId] IN ({formattedIds})";
            db.Database.ExecuteSqlRaw(sqlQuery);

            sqlQuery = $"UPDATE parents SET [IsEligibleToSharePensionAmount] = 'true' WHERE [PersonId] IN ({formattedIds})";
            db.Database.ExecuteSqlRaw(sqlQuery);


            sqlQuery = $"UPDATE siblings SET [IsEligibleToSharePensionAmount] = 'true' WHERE [PersonId] IN ({formattedIds})";
            db.Database.ExecuteSqlRaw(sqlQuery);

            sqlQuery = $"UPDATE spouses SET [IsEligibleToSharePensionAmount] = 'true' WHERE [PersonId] IN ({formattedIds})";
            db.Database.ExecuteSqlRaw(sqlQuery);



            // need to update the task status
            //TaskRequest taskRequest = db.TaskRequests.Include("TaskStatus").Where(t => t.TaskRequestID == taskreqid).FirstOrDefault();

            //db.Entry(taskRequest).Reload();
            TaskRequest taskRequest = db.TaskRequests.Include("TaskStatus").Where(t => t.TaskRequestID == taskreqid).FirstOrDefault();

            //Domain.Entities.TaskStatus taskStatus = new Domain.Entities.TaskStatus
            //{
            //    ResearcherStatus = "Submitted",
            //    DateCompleted = DateTime.Now
            //};

            //taskRequest.TaskStatus.ResearcherStatus = "Submitted";
            //taskRequest.TaskStatus.DateCompleted = DateTime.Now;

            Domain.Entities.TaskStatus taskStatus = null; ;

            if (taskRequest.TaskStatus.TaskStatusID == 0)
            {
                taskStatus = new Domain.Entities.TaskStatus
                {
                    ResearcherStatus = "Submitted",
                    ManagerStatus = "Pending",
                    TopManagerStatus = "Pending",
                    DateCompleted = DateTime.Now
                };
                taskRequest.TaskStatus = taskStatus;
                db.Entry(taskRequest.TaskStatus).State = EntityState.Added;
            }

            else
            {
                taskRequest.TaskStatus.ResearcherStatus = "Submitted";
                taskRequest.TaskStatus.DateCompleted = DateTime.Now;
                db.Entry(taskRequest.TaskStatus).State = EntityState.Modified;
            }
            //db.Entry(taskRequest).Reload();
            //taskRequest.TaskStatus = taskStatus;
            //db.Entry(taskRequest).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("MyTasks");
        }


        //[Authorize(Roles = "requester")]
        public IActionResult MyRequests()
        {



            // TODO:
            // get the current user login id
            // get the service number from login id
            string logedinUserServiceNo = User.Identity.Name;
            // Data Layer
            // Add repository for TaskRequest

            // 
            // get all the tasks for that  from service number
            var myrequests = db.TaskRequests.Include("TaskStatus").Include("WelfareForm").Where(t => t.FromServiceNo == logedinUserServiceNo).ToList();
            List<RequestTaskViewModel> tasksVM = new List<RequestTaskViewModel>();
            // convert TaskRequest Domain Model to RequestTaskViewModel
            tasksVM = (from t in myrequests
                       select new RequestTaskViewModel
                       {
                           FormName = t.WelfareForm.FormName,
                           FromServiceNo = t.FromServiceNo,
                           ServiceNo = t.WelfareForm.ServiceNo,
                           TaskRequestID = t.TaskRequestID,
                           ResearcherStatus = t.TaskStatus.ResearcherStatus,
                           ManagerStatus = t.TaskStatus.ManagerStatus,
                           TopManagerStatus = t.TaskStatus.TopManagerStatus
                       }).ToList();

            // create MyRequestViewModel and fill into this
            // return that MyRequestViewModel to view
            return View(tasksVM);
        }

        public IActionResult Details(string serviceNo, int taskreqid)
        {

            var taskReq = db.TaskRequests.Include("Attachments").Where(t => t.TaskRequestID == taskreqid).FirstOrDefault();
            ViewBag.TaskReqID = taskreqid;
            ViewBag.Attachments = taskReq.Attachments;
            var details = empRepo.GetEmployeeDetails(serviceNo).FirstOrDefault();
            //childrens = new List<Children>().ToList<Person>();
            return View(details);
        }

        public IActionResult ManagerAction(string manageraction, string managercomment, int taskreqid)
        {
            var taskRequest = db.TaskRequests.Include("TaskStatus").Where(t => t.TaskRequestID == taskreqid).FirstOrDefault();

            taskRequest.TaskStatus.ManagerStatus = manageraction;
            taskRequest.TaskStatus.ManagerComment = managercomment;
            if (manageraction == "Returned")
                taskRequest.TaskStatus.ResearcherStatus = "Pending";
            db.SaveChanges();

            return RedirectToAction("MyTasks");
        }
    }
}
