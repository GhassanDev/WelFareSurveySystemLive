using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Domain.Business
{
    public class WelfareSurveySystemBusiness : IWelfareSurveySystemBusiness
    {

        //========================================================================
        private readonly IEmployeeRepository repo;

        public int ParentId { get; private set; }

        //use some Ioc (Invertion of Control) to inject the depandancy object(obove one)
        public WelfareSurveySystemBusiness(IEmployeeRepository repository)
        {
            this.repo = repository;
        }
        //==========================================================================



        //operation Deceased
        public void SaveEmployee(Employee employee)
        {
            repo.SaveEmployee(employee);
        }

        public void DeleteEmployee(int EmployeeID)
        {
            repo.DeleteEmployee(EmployeeID);
        }

        public Employee GetEmployee(int EmployeeID)
        {
            return repo.GetEmployee(EmployeeID);
        }

        public List<Employee> GetAllEmployees()
        {
            return repo.GetAllEmployees();
        }

        public void EditEmployee(int EmployeeID, Employee employee)
        {
            repo.EditEmployee(EmployeeID, employee);
        }
        //operation children

        public void SaveChildren(int ChildrenId, Children children)
        {
            repo.SaveChildren(ChildrenId, children);
        }

        public void DeleteChildren(int id)
        {
            repo.DeleteChildren(id);
        }

        public void EditChildren( Children children)
        {
            repo.EditChildren(children);
        }
        //operation parent

        public void SaveParent(int ParentId, Parent parent)
        {
            repo.SaveParent(ParentId, parent);
        }

        public void DeleteParent(int id)
        {
            repo.DeleteParent(id);
          
        }

        
        public void EditParent(Parent parent)
        {
            // You can add any business logic here
            repo.EditParent(parent);
        }
        //operation PersonalInfo

        //operation RealEstate

        public void SaveRealEstate(RealEstate realEstate)
        {
            repo.SaveRealEstate(realEstate);
        }

        public void DeleteRealEstate(int DeceasedID, int RealEstateId)
        {
            repo.DeleteRealEstate(DeceasedID, RealEstateId);
        }

        public void EditRealEstate(int DeceasedID, int RealEstateId, RealEstate realEstate)
        {
            repo.EditRealEstate(DeceasedID, RealEstateId, realEstate);
        }

        public List<RealEstate> GetAllRealEstate()
        {
            return repo.GetAllRealEstate();
        }
        //operation Resercher

        

        public void SaveSibling(int SiblingId, Sibling sibling)
        {
            repo.SaveSibling(SiblingId, sibling);
        }

        public void DeleteSibling(int id)
        {
            repo.DeleteSibling(id);
        }

        public void EditSibling(Sibling sibling)
        {
            repo.EditSibling(sibling);
            
        }
        //operation Spouse
        public void SaveSpouse(int SpouseId, Spouse spouse)
        {
            repo.SaveSpouse(SpouseId, spouse);
        }

        public void DeleteSpouse(int id)
        {
            repo.DeleteSpouse(id);
        }

        public void EditSpouse( Spouse spouse)
        {
            repo.EditSpouse(spouse);
        }

        public List<Parent> GetParents()
        {
            //throw new NotImplementedException();
            //TODO:
            // List<Parent> parents = repo.GetParents(empID);
            return repo.GetParents();
           // return parents;
        }

        public void SaveParent(Parent parent)
        {
            repo.SaveParent(ParentId, parent);
        }

        public List<Children> GetChildren(int empID)
        {
            List<Children> Childrens = repo.GetChildren(empID);

            return Childrens;
        }
        public Children GetChildrens(int id)
        {
            return repo.GetChildrens().Where(p => p.PersonId == id).FirstOrDefault();
        }
        public List<Spouse> GetSpouse(int empID)
        {
            List<Spouse> Spouses = repo.GetSpouse(empID);

            return Spouses;
        }

        public List<Sibling> GetSibling(int empID)
        {
            List<Sibling> Siblings = repo.GetSibling(empID);

            return Siblings;
        }

        public List<RealEstateType> GetRealEstateTypes()
        {
            return repo.GetRealEstateTypes();
        }

        //public void DeleteParent(int DeceasedID, int ParentId)
        //{
        //    throw new NotImplementedException();
        //}

        public Parent GetParent(int id)
        {
           return  repo.GetParents().Where(p=>p.PersonId == id).FirstOrDefault();
        }

        public List<Parent> GetAllParent()
        {
            return repo.GetAllParents();
        }

        public List<Parent> GetAllParents()
        {
            return repo.GetAllParents();
        }

        public Sibling GetSiblings(int id)
        {
            return repo.GetSiblings().Where(p => p.PersonId == id).FirstOrDefault();
        }

        public Spouse GetSpouses(int id)
        {
            return repo.GetSpouses().Where(p => p.PersonId == id).FirstOrDefault();
        }

        //public List<Parent> GetAllParent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}