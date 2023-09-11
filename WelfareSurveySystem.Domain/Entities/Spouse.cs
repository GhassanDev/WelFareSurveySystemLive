using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Spouse : Person
    {
        public int SpouseId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
    }
}
