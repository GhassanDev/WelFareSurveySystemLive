using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Data
{
    public class DeceasedRepository : IDeceasedRepository
    {
        private WelfareSurveySystemDBContext db;// = new WelfareSurveySystemDBContext();
        public DeceasedRepository(WelfareSurveySystemDBContext db)
        {
            this.db = db;
        }


        public Employee GetDeceasedByServiceNo(string ServiceNo)
        {
            return db.Employees.Where(e => e.ServiceNo == ServiceNo).FirstOrDefault();
        }

        public void SaveDeceased(TaskRequest taskRequest)
        {
            db.TaskRequests.Add(taskRequest);
            db.SaveChanges();
        }
    }
}
