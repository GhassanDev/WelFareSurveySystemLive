using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Parent : Person
    {
        //public int ParentId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
    }
}
