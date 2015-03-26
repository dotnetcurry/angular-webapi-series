using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class ProjectTasksRepository
    {
        private static ProjectTrackingDBEntities dataContext = new ProjectTrackingDBEntities();
        public static List<ProjectTask> GetAllProjectTasks()
        {
            var query = from projTasks in dataContext.ProjectTasks
                        select projTasks;
            return query.ToList();
        }
        public static ProjectTask GetProjectTask(int ProjectTaskID)
        {
            var query = (from projTasks in dataContext.ProjectTasks
                        where projTasks.ProjectTaskID==ProjectTaskID
                        select projTasks).SingleOrDefault();
            return query;
        }
        public static List<ProjectTask> InsertProjectTask(ProjectTask PT)
        {
            dataContext.ProjectTasks.Add(PT);
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }
        public static List<ProjectTask> UpdateProjectTask(ProjectTask PT)
        {
            var projectTask = (from projTasks in dataContext.ProjectTasks
                        where projTasks.ProjectTaskID == PT.ProjectTaskID
                        select projTasks).SingleOrDefault();
            projectTask.AssignedTo = PT.AssignedTo;
            projectTask.TaskStartDate = PT.TaskStartDate;
            projectTask.TaskEndDate = PT.TaskEndDate;
            projectTask.TaskCompletion = PT.TaskCompletion;
            projectTask.UserStoryID = PT.UserStoryID;
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }
        public static List<ProjectTask> DeleteProjectTask(ProjectTask PT)
        {
            var projectTask = (from projTasks in dataContext.ProjectTasks
                               where projTasks.ProjectTaskID == PT.ProjectTaskID
                               select projTasks).SingleOrDefault();
            dataContext.ProjectTasks.Remove(projectTask);
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }
    }
}