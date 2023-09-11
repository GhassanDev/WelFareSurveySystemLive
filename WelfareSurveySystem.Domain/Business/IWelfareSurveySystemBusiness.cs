using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Domain.Business
{
    public interface IWelfareSurveySystemBusiness
    {
        //First I add method for initializing the repository:
        //void InitializeRepository(IWelfareSurveyRepository repository);
        //operation Deceased
        void SaveEmployee(Employee employee);
        void DeleteEmployee(int EmployeeID);
        Employee GetEmployee(int EmployeeID);
        List<Employee> GetAllEmployees();
        void EditEmployee(int EmployeeID, Employee employee);

        // TODO
        // add all remaining CRUD operations below

        //operation children
        void SaveChildren(int ChildrenId, Children children);
        void DeleteChildren(int id);
        void EditChildren(Children children);
        List<Children> GetChildren(int empID);
        Children GetChildrens(int id);
        //operation parent
        void SaveParent(int empID, Parent parent);
        void DeleteParent(int id);
        void EditParent( Parent parent);
       // void UpdateParent(Parent parent);
        Parent GetParent(int id);
        //List<Parent> GetParents(Parent);
        List<Parent> GetAllParent();
        List<Parent> GetAllParents();
        //operation PersonalInfo

        //operation RealEstate
        void SaveRealEstate(RealEstate realEstate);
        void DeleteRealEstate(int DeceasedID, int RealEstateId);
        void EditRealEstate(int DeceasedID, int RealEstateId, RealEstate realEstate);
        List<RealEstate> GetAllRealEstate();

        //operation Resercher
        //void SaveResercher(int ResercherId, Resercher resercher);
        //void DeleteResercher(int DeceasedID, int ResercherId);
        //void EditResercher(int DeceasedID, int ResercherId, Resercher resercher);

        //operation Sibling
        void SaveSibling(int SiblingId, Sibling sibling);
        void DeleteSibling(int id);
        void EditSibling(Sibling sibling);
        List<Sibling> GetSibling(int empID);
        Sibling GetSiblings(int id);
        //operation Spouse
        void SaveSpouse(int SpouseId, Spouse spouse);
        void DeleteSpouse(int id);
        void EditSpouse(Spouse spouse);
        List<Spouse> GetSpouse(int empID);
        Spouse GetSpouses(int id);
        List<RealEstateType> GetRealEstateTypes();

        //void SaveParent(Parent parent);
    }
}
