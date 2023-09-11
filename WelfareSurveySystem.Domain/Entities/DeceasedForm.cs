namespace WelfareSurveySystem.Domain.Entities
{
    public class DeceasedForm : WelfareForm
    {
        public int DeceasedFormID { get; set; }

        public DateTime DateOfDeceased { get; set; }
        public string ReasonOfDeceased { get; set; }

        //public string ServiceNo { get; set; }
        //[ForeignKey("Employe")]
        //public int EmployeeID { get; set; }
        //public Employee DeceasedEmployee { get; set; }



    }
}
