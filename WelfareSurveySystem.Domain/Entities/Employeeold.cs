using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    // Added this general entity, and we can divided it to many. 
    public class Family
    {
        public int FamilyId { get; set; }
        public string Name { get; set; }
        public int IdCard { get; set; }
        public DateTime BithDay { get; set; }
        public string HealthStatues { get; set; }

        public string JobName { get; set; }
        public string MaritalStatus { get; set; }
        public string Stay { get; set; }

    }
    public class Parent1 : Family
    {
        [Key]
        public int ParentId { get; set; }


        // Foreign key to Family entity
        //public int FamilyId { get; set; }
        //public Family Family { get; set; }
    }

    public class Child : Family
    {
        [Key]
        public int ChildId { get; set; }

        // Foreign key to Family entity
        //public int FamilyId { get; set; }
        //public Family Family { get; set; }
    }


    public class Died
    {
        public int DiedId { get; set; }
        public string DiedName { get; set; }
        public string DiedReasons { get; set; }
        public DateTime? DiedDate { get; set; }
        public bool Retired { get; set; }
        public string CourtName { get; set; }

    }


    public class Employees
    {
        [Key]
        public int ProfileNo { get; set; }

        public string EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeRank { get; set; }

        public int UnitId { get; set; }

        public int EmployeeStatusCode { get; set; }

        public string EmployeeStatus { get; set; }

        public DateTime? EnlistmentDate { get; set; }

        public DateTime? RetirementDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public string City { get; set; }
        public string Village { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public byte[] Photo { get; set; }

        public string Remarks { get; set; }

        public string EmployeeNameAr { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int InsertedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string NewRemarks { get; set; }

        [Required]
        public Guid EmployeeStatuId { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        // Foreign key to Died entity
        public int? DiedId { get; set; }
        public Died Died { get; set; }
        public Family Family { get; set; }
    }

   
}
