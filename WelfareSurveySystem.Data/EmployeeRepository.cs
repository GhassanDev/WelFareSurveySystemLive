using Microsoft.EntityFrameworkCore;
using System.Xml;
using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.Domain.Entities;

namespace WelfareSurveySystem.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //private WelfareSurveySystemDBContext db = new WelfareSurveySystemDBContext();
        private WelfareSurveySystemDBContext db;// = new WelfareSurveySystemDBContext();

        public EmployeeRepository(WelfareSurveySystemDBContext db)
        {
            this.db = db;
        }


        //operation children
        //public void DeleteChildren(int DeceasedID, int ChildrenId)
        //{

        //    var ChildrendDel = db.Childrens.Find(ChildrenId);

        //    db.Childrens.Remove(ChildrendDel);

        //    db.SaveChanges();
        //}
        public void DeleteChildren(int id)
        {
            db.Childrens.Remove(db.Childrens.Find(id));
            db.SaveChanges();
        }
        public void EditChildren(Children children)
        {
            db.Entry(children).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }
        public void SaveChildren(int ChildrenId, Children children)
        {
            db.Childrens.Add(children);
            db.SaveChanges();
        }
        //operation parent
        //public void DeleteParent(int DeceasedID, int ParentId)
        //{

        //    var ParentDel = db.Parents.Find(ParentId);

        //    db.Parents.Remove(ParentDel);
        //}
        public void DeleteParent(int id)
        {
            db.Parents.Remove(db.Parents.Find(id));
            db.SaveChanges();
        }
        public void SaveParent(int ParentId, Parent parent)
        {
            SaveParent(ParentId, parent, db);
        }

        public void SaveParent(int ParentId, Parent parent, WelfareSurveySystemDBContext db)
        {
            db.Parents.Add(parent);
            db.SaveChanges();
        }
        
            public void EditParent(int personId, int ParentId, Parent parent)
            {
                db.Entry(parent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
        
            //operation PersonalInfo
            //operation RealEstate
            public void DeleteRealEstate(int DeceasedID, int RealEstateId)
        {
            var RealEstateDel = db.RealEstates.Find(RealEstateId);

            db.RealEstates.Remove(RealEstateDel);
            db.SaveChanges();
        }
        public List<RealEstate> GetAllRealEstate()
        {
            return db.RealEstates.ToList();
        }
        public void SaveRealEstate(RealEstate realEstate)
        {
            db.RealEstates.Add(realEstate);
            db.SaveChanges();
        }
        public void EditRealEstate(int DeceasedID, int RealEstateId, RealEstate realEstate)
        {
            db.Entry(realEstate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }
        
        //operation Sibling
        public void DeleteSibling(int id)
        {
            db.Siblings.Remove(db.Siblings.Find(id));
            db.SaveChanges();
        }
        public void EditSibling(Sibling sibling)
        {
            db.Entry(sibling).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }
        public void SaveSibling(int SiblingId, Sibling sibling)
        {
            db.Siblings.Add(sibling);
            db.SaveChanges();
        }
        //operation Spouse
        public void DeleteSpouse(int id)
        {
            db.Spouses.Remove(db.Spouses.Find(id));
            db.SaveChanges();
        }
        public void EditSpouse(Spouse spouse)
        {
            db.Entry(spouse).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }
        public void SaveSpouse(int SpouseId, Spouse spouse)
        {
            db.Spouses.Add(spouse);
            db.SaveChanges();
        }

        public void SaveEmployee(Employee employee)
        {
            //employee.Address = new Address { City = "city", Region = "re", Village = "v1" };
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        void IEmployeeRepository.DeleteEmployee(int employeeID)
        {
            // get the emp to delete from dbset
            var EmployeeDel = db.Employees.Find(employeeID);
            // remove that obj from dbset
            db.Employees.Remove(EmployeeDel);

            db.SaveChanges();
        }

        Employee IEmployeeRepository.GetEmployee(int EmployeeID)
        {
            return db.Employees.Find(EmployeeID);
        }

        List<Employee> IEmployeeRepository.GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        void IEmployeeRepository.EditEmployee(int EmployeeID, Employee employee)
        {
            db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public void SaveParent(object parentId, Parent parent)
        {
            db.Parents.Add(parent);
            db.SaveChanges();
        }

        public void SaveParent(Parent parent)
        {
            db.Parents.Add(parent);
            db.SaveChanges();
        }

        public void SaveParent(Parent parent, int empID)
        {
            db.Parents.Add(parent);
            db.SaveChanges();
        }

        public List<Parent> GetParents()
        {
           // return db.Parents.Where(p => p.EmployeeID == empID).ToList();
            return db.Parents.ToList();
        }

        public List<Children> GetChildren(int empID)
        {
            return db.Childrens.Where(p => p.EmployeeID == empID).ToList();
        }
        public List<Spouse> GetSpouse(int empID)
        {
            return db.Spouses.Where(p => p.EmployeeID == empID).ToList();
        }
        public Spouse GetSpouses(int id)
        {
            return db.Spouses.Find(id);
        }
        public List<Sibling> GetSibling(int empID)
        {
            return db.Siblings.Where(p => p.EmployeeID == empID).ToList();
        }
        public Sibling GetSiblings(int id)
        {
            return db.Siblings.Find(id);
        }
        public List<Employee> GetEmployeeDetails(string serviceNo)
        {
            return db.Employees
                .Include("Childrens.Address")
                .Include("Siblings")
                .Include("Parents")
                .Include("Spouses")
                .Include("RealEstates")
                .Include("Documents")
                .Include("Address")
                .Where(e => e.ServiceNo == serviceNo).ToList();
        }

        public List<RealEstateType> GetRealEstateTypes()
        {
            return db.RealEstateTypes.ToList();
        }
        public List<Parent> GetAllParents()
        {
            return db.Parents.ToList();
        }
        public Parent GetAllParents(int id)
        {
            return db.Parents.Find(id);
        }

        public void EditParent(Parent parent)
        {
            db.Entry(parent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public Children GetChildrens(int id)
        {
            return db.Childrens.Find(id);
        }

        public List<Children> GetChildrens()
        {
            return db.Childrens.ToList();
        }





        public Sibling GetSplings(int id)
        {
            return db.Siblings.Find(id);
        }

        public List<Sibling> GetSiblings()
        {
            return db.Siblings.ToList();
        }

        public List<Spouse> GetSpouses()
        {
            return db.Spouses.ToList();
        }





        //TODO : Implement the remaining interface methods

    }
}
