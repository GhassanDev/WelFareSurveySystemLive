using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WelfareSurveySystem.Domain.Entities
{
    // Added this general entity, and we can divided it to many. 
   

    public class OrgUnits
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public string UnitDescriptionE { get; set; }

        public string UnitDescriptionA { get; set; }

        public DateTime? InsertedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

    public class Permissions
    {
        public int PermissionId { get; set; }

        [Required]
        public string PermissionDescription { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public string ControllerName { get; set; }

        [Required]
        public bool IsHideFromMenu { get; set; }
    }
    public class DemandWorkFlows
    {
        public int Id { get; set; }

        [Required]
        public Guid ResearchDemandId { get; set; }

        public Guid? WorkActivitiesId { get; set; }

        public string Remarks { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? CreatedByUserId { get; set; }
    }

    public class ReasonTypes
    {
        [Key]
        public Guid Id { get; set; }

        public string ResearchTypeE { get; set; }

        public string ResearchTypeA { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int CreatedBy { get; set; }

        public string PrefIx { get; set; }
    }

    public class RegionOfficeApplicationUsers
    {
        [Key, Column(Order = 1)]
        public int RegionOffice_RegionOfficeCode { get; set; }

        [Key, Column(Order = 2)]
        public int ApplicationUser_Id { get; set; }
    }

    public class RegionOffices
    {
        [Key]
        public int RegionOfficeCode { get; set; }

        public string RegionOfficeNameEnglish { get; set; }

        public string RegionOfficeNameArabic { get; set; }

        public string ContactName { get; set; }

        public int ContactNumber { get; set; }

        public string Remarks { get; set; }
    }

    public class ResearchDemands
    {
        [Key]
        public Guid Id { get; set; }

        public int ProfileNo { get; set; }

        public string EmployeeStatus { get; set; }

        public string Rank { get; set; }

        [Required]
        public Guid ReasonId { get; set; }

        public int OrgUnitId { get; set; }

        public Guid? WorkFlowActivitiesId { get; set; }

        public int? RegionOfficeCode { get; set; }

        [Required]
        public string Remarks { get; set; }

        public DateTime? InsertedDate { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }

        [Required]
        public int TransactionStatus { get; set; }

        public string EmployeeServiceNo { get; set; }
    }

    public class ResearchDemandUploadeds
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ResearchDemandId { get; set; }

        public string Remarks { get; set; }

        public string FileName { get; set; }

        public Guid? FileId { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public string FileTitle { get; set; }

        public DateTime? InsertedDate { get; set; }

        [Required]
        public int UploadedBy { get; set; }

        public string UploadType { get; set; }
    }

    public class ReservedForces
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Pf { get; set; }

        public string DocName { get; set; }

        public string DocExt { get; set; }

        public string ContentType { get; set; }

        public DateTime? InsertedDate { get; set; }

        [Required]
        public int UploadedBy { get; set; }
    }

    public class RolePermission
    {
        [Key, Column(Order = 1)]
        public int RoleId { get; set; }

        [Key, Column(Order = 2)]
        public int PermissionId { get; set; }
    }

    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleDescription { get; set; }

        [Required]
        public bool IsSysAdmin { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class ServiceInfoes
    {
        [Key]
        public int Id { get; set; }

        public string ServiceDescriptionE { get; set; }

        public string ServiceDescriptionA { get; set; }

        public DateTime? InsertedDate { get; set; }

        [Required]
        public int FroceId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string ServiceShortName { get; set; }
    }

    public class SystemLogs
    {
        public int Id { get; set; }

        public string AppLoggedInUser { get; set; }

        public string OsLoggedInUser { get; set; }

        public string Action { get; set; }

        [Required]
        public DateTime LoggedDate { get; set; }

        public string LoggedMachineName { get; set; }
    }

    public class TrackingUsers
    {
        public int Id { get; set; }

        public string LoggedUserName { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }

        public string LogType { get; set; }

        public string LogMessage { get; set; }

        public string LogModule { get; set; }
    }

    public class UserInRoles
    {
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Key, Column(Order = 2)]
        public int RoleId { get; set; }
    }

    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserFullName { get; set; }

        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public string Salt { get; set; }

        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        public string UserImage { get; set; }

        public DateTime? LastLogin { get; set; }

        public string Remarks { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsUserLock { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsForcePasswordChange { get; set; }

        [Required]
        public int FailedAttempts { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [Required]
        public int LastModifiedUserId { get; set; }

        [Required]
        public bool IsForceLogout { get; set; }
    }

    public class WorkFlowActivityAudits
    {
        public int Id { get; set; }

        [Required]
        public Guid WorkFlowActivityId { get; set; }

        public string Remarks { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public DateTime InsertedDate { get; set; }

        [Required]
        public int InsertedUserId { get; set; }
    }

    public class WorkFlowActivityStatus
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }

    public class WorkFlowActivityUsers
    {
        [Key, Column(Order = 1)]
        public Guid WorkFlowActivityId { get; set; }

        [Key, Column(Order = 2)]
        public int UserId { get; set; }
    }

    public class WorkFlowActivities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid WorkFlowId { get; set; }

        public string ActivityDescriptionE { get; set; }

        public string ActivityDescriptionA { get; set; }

        [Required]
        public bool IsEdit { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public bool IsStart { get; set; }

        [Required]
        public bool IsEnd { get; set; }

        public int NextActivityTypeId { get; set; }

        public int? NextActivityId { get; set; }

        [Required]
        public DateTime InsertedDate { get; set; }

        [Required]
        public int InsertedUserId { get; set; }
    }
}
