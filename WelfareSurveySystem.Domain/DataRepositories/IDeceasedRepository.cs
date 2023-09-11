using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Domain.DataRepositories
{
    public interface IDeceasedRepository
    {
        void SaveDeceased(TaskRequest taskRequest);
        Employee GetDeceasedByServiceNo(string ServiceNo);
        //void DeleteDeceased(int TaskRequestID);
        //TaskRequest GetDeceased(int TaskRequestID);
        //List<TaskRequest> GetAllTaskRequests();


    }
}


