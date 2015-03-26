using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class EmployeesRepository
    {
        private static ProjectTrackingDBEntities dataContext = new ProjectTrackingDBEntities();
        public static List<Employee> GetAllEmployees()
        {
            var query = from employee in dataContext.Employees
                        select employee;
            return query.ToList();
        }

        public static List<Employee> SearchEmployeesByName(string employeeName)
        {
            var query = from employee in dataContext.Employees
                        where employee.EmployeeName.Contains(employeeName)
                        select employee;
            return query.ToList();
        }
        public static Employee GetEmployee(int EmployeeID)
        {
            var query = from employee in dataContext.Employees
                        where employee.EmployeeID == EmployeeID
                        select employee;
            return query.SingleOrDefault();
        }
        public static List<Employee> InsertEmployee(Employee e)
        {
            dataContext.Employees.Add(e);
            dataContext.SaveChanges();
            return GetAllEmployees();
        }
        public static List<Employee> UpdateEmployee(Employee e)
        {
            var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            emp.EmployeeName = e.EmployeeName;
            emp.Designation = e.Designation;
            emp.ContactNo = e.ContactNo;
            emp.EMailID = e.EMailID;
            emp.SkillSets = e.SkillSets;
            dataContext.SaveChanges();
            return GetAllEmployees();
        }
        public static List<Employee> DeleteEmployee(Employee e)
        {
            var emp = (from employee in dataContext.Employees
                       where employee.EmployeeID == e.EmployeeID
                       select employee).SingleOrDefault();
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
            return GetAllEmployees();
        }
    }
}