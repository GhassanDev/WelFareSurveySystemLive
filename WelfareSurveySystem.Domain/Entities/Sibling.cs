using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Sibling : Person
    {
        public int SiblingId { get; set; }
        public string BrotherOrStepBrother { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
    }
}
