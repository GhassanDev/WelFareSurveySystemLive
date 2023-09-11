using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Domain.DataRepositories
{
    public interface IEmployeeRepository
    {

        //operation Deceased
        void SaveEmployee(Employee employee);
        void DeleteEmployee(int EmployeeID);
        Employee GetEmployee(int EmployeeID);
        List<Employee> GetAllEmployees();
        void EditEmployee(int EmployeeID, Employee employee);

        // TODO
        // add all remaining CRUD operations below

        void SaveChildren(int ChildrenId, Children children);
        void DeleteChildren(int id);
        void EditChildren(Children children);
        List<Children> GetChildrens();
        List<Children> GetChildren(int empID);
        //operation parent
        void SaveParent(Parent parent, int empID);
        void DeleteParent(int id);
        void EditParent(Parent parent);

        //operation PersonalInfo

        //operation RealEstate
        void SaveRealEstate(RealEstate realEstate);
        void DeleteRealEstate(int DeceasedID, int RealEstateId);
        void EditRealEstate(int DeceasedID, int RealEstateId, RealEstate realEstate);
        List<RealEstate> GetAllRealEstate();

        //operation Resercher
       
        //operation Sibling
        void SaveSibling(int SiblingId, Sibling sibling);
        void DeleteSibling(int id);
       
        List<Sibling> GetSibling(int empID);
        void EditSibling(Sibling sibling);
        List<Sibling> GetSiblings();
        //operation Spouse
        void SaveSpouse(int SpouseId, Spouse spouse);
        void DeleteSpouse(int id);
        void EditSpouse(Spouse spouse);
        List<Spouse> GetSpouse(int empID);
        List<Spouse> GetSpouses();
        void SaveParent(object parentId, Parent parent);
        void SaveParent(Parent parent);
        List<Parent> GetParents();
        //Parent GetParent(int id);

        List<Employee> GetEmployeeDetails(string serviceNo);
        List<RealEstateType> GetRealEstateTypes();
        List<Parent> GetAllParents();
    }
}
