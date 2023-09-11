using System.ComponentModel;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.WebUI.Models
{
    public class RequestTaskViewModel
    {
        [DisplayName("Form Name")]
        public string FormName { get; set; }
        [DisplayName("Task Request ID")]
        public int TaskRequestID { get; set; }
        [DisplayName("From Service Number")]
        public string FromServiceNo { get; set; }
        [DisplayName("Service Number")]
        public string ServiceNo { get; set; }
        [DisplayName("Researcher Status")]
        public string ResearcherStatus { get; set; }
        [DisplayName("Manager Status")]
        public string ManagerStatus { get; set; }
        [DisplayName("Top Manager Status")]
        public string TopManagerStatus { get; set; }
        [DisplayName("Manager Comment")]
        public string ManagerComment { get; set; }
        [DisplayName("Top Manager Comment")]
        public string TopManagerComment { get; set; }
        public virtual List<Document> Attachments { get; set; } = new List<Document>();



    }
}
