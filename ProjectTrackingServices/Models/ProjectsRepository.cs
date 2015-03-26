using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class ProjectsRepository : IDisposable
    {
        private ProjectTrackingDBEntities dataContext;

        public ProjectsRepository()
        {
            dataContext = new ProjectTrackingDBEntities();
        }

        public List<Project> GetAllProjects()
        {
            
            var query = from project in dataContext.Projects
                        select project;
            return query.ToList();
        }
        public Project GetProject(int ProjectID)
        {
            var query = from project in dataContext.Projects
                        where project.ProjectID==ProjectID
                        select project;
            return query.SingleOrDefault();
        }
        public List<Project> GetProjectByName(string projectName)
        {
            var query = from project in dataContext.Projects
                        where project.ProjectName.Contains(projectName)
                        select project;
            return query.ToList();
        }
        public List<Project> InsertProject(Project p)
        {
            dataContext.Projects.Add(p);
            dataContext.SaveChanges();
            return GetAllProjects();
        }
        public List<Project> UpdateProject(Project p)
        {
            var proj = (from project in dataContext.Projects
                       where project.ProjectID == p.ProjectID
                       select project).SingleOrDefault();
            proj.ProjectName = p.ProjectName;
            proj.StartDate = p.StartDate;
            proj.EndDate = p.EndDate;
            proj.ClientName = p.ClientName;
            dataContext.SaveChanges();
            return GetAllProjects();
        }
        public List<Project> DeleteProject(int projectId)
        {
            var proj = (from project in dataContext.Projects
                        where project.ProjectID == projectId
                        select project).SingleOrDefault();
            dataContext.Projects.Remove(proj);
            dataContext.SaveChanges();
            return GetAllProjects();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}