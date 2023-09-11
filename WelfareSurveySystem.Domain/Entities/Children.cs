using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Children : Person
    {
        public int ChildrenId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
    }
}
