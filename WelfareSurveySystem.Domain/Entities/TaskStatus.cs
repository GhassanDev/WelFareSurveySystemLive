namespace WelfareSurveySystem.Domain.Entities
{
    public class TaskStatus
    {
        public int TaskStatusID { get; set; }
        public int TaskRequestID { get; set; }
        public string ResearcherStatus { get; set; } = "Pending"; // Pending/Submitted
        public string ManagerStatus { get; set; } = "Pending"; // Pending/Approved/Rejected/Returned
        public string TopManagerStatus { get; set; } = "Pending"; // Pending/Approved/Rejected/Returned
        public string ManagerComment { get; set; }
        public string TopManagerComment { get; set; }
        public DateTime DateCompleted { get; set; } //Researcher submit date
        public string CompletedByServiceNo { get; set; }
    }
}
