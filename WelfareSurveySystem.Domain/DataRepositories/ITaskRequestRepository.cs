using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Domain.DataRepositories
{
    public interface ITaskRequestRepository
    {
        List<TaskRequest> GetAllTaskByBranchID(string branch);
    }
}
