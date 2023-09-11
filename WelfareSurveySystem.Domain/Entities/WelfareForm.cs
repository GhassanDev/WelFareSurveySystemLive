namespace WelfareSurveySystem.Domain.Entities
{
    public abstract class WelfareForm
    {
        public int WelfareFormId { get; set; }
        public string FormName { get; set; }
        public string ServiceNo { get; set; }
    }
}
