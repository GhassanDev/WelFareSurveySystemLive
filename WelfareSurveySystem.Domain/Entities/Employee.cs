using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WelfareSurveySystem.Domain.Entities
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }
        //public PersonalInfo PersonalInfo { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("ID Card Number")]
        public int IdCard { get; set; }
        [DisplayName("Service Number")]
        public string ServiceNo { get; set; }
        [DisplayName("Force Name")]
        public string ForceName { get; set; }

        public DateTime SysDate { get; set; }
        [DisplayName("Is Retired")]
        public bool Retired { get; set; } = false;
        public string? Branch { get; set; }

        public virtual Address Address { get; set; }

        [DisplayName("Shekh Name")]
        public string ShekhName { get; set; }
        [DisplayName("Court Name")]
        public string CourtName { get; set; }
        [DisplayName("Email ID")]
        public string EmailID { get; set; }

        [DisplayName("Is Deceased")]
        public bool IsDeceased { get; set; } = false;

        //private Parent[] parents = new Parent[2];

        // private Spouse[] spouses = new Spouse[4];

        public virtual List<Children> Childrens { get; set; } = new List<Children>();

        public virtual List<Sibling> Siblings { get; set; } = new List<Sibling>();
        //public virtual Parent[] Parents { get => parents; set => parents = value; }
        //public virtual Spouse[] Spouses { get => spouses; set => spouses = value; }

        public virtual List<Parent> Parents { get; set; } = new List<Parent>();
        public virtual List<Spouse> Spouses { get; set; } = new List<Spouse>();
        public virtual List<RealEstate> RealEstates { get; set; } = new List<RealEstate>();
        public virtual List<WelfareForm> ResearchedWelfareForms { get; set; }
        public virtual List<Document> Documents { get; set; } = new List<Document>();
    }
}
