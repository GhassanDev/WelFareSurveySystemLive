
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.WebUI.Models
{
    public class TaskRequestViewModel
    {
        //[Required]
        [DisplayName("Requester Service Number")]
        public string FromServiceNo { get; set; }
        [Required]
        [DisplayName("Deceased Service Number")]
        public string ServiceNo { get; set; }
        //[Required]
        [DisplayName("Deceased Full Name")]
        public bool? IsDeceased { get; set; } = false;
        public string FullName { get; set; }
        [Required]
        [DisplayName("Branch Assigned To")]
        public string Branch { get; set; }
        //[Required]
        [DisplayName("Date Of Deceased")]
        public DateTime DateOfDeceased { get; set; }
        //[Required]
        [DisplayName("Reason Of Death")]
        public string ReasonOfDeceased { get; set; }
        public List<IFormFile> Uploads { get; set; }
        //public IFormFile UploadFile { get; set; }
        //public string UploadFilePath { get; set; }



        public virtual List<Document> Attachments { get; set; } = new List<Document>();

    }
}
