namespace WelfareSurveySystem.Domain.Entities
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int IdCard { get; set; }
        public DateTime BirthDay { get; set; }
        public string HealthStatues { get; set; }

        public string JobName { get; set; }
        public string MaritalStatus { get; set; }
        public Address Address { get; set; }

        public bool IsEligibleToSharePensionAmount { get; set; } = false;
    }
}
