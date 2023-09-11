namespace WelfareSurveySystem.Domain.Entities
{
    public class TaskRequest
    {
        public int TaskRequestID { get; set; }
        public DateTime DateRequested { get; set; }
        public string FromServiceNo { get; set; }
        public string Branch { get; set; }

        public virtual WelfareForm WelfareForm { get; set; }

        public virtual TaskStatus TaskStatus { get; set; } = new TaskStatus();

        public virtual List<Document> Attachments { get; set; } = new List<Document>();
        //public string UploadFilePath { get; set; }

    }
}
