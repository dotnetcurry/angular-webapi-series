using ProjectTrackingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectTrackingServices.Controllers
{
    [EnableCors(origins: "http://localhost:55058", headers: "*", methods: "*")]
    public class PTProjectTasksController : ApiController
    {
        // GET api/ptprojecttasks
        [Route("api/ptprojecttasks")]
        public IEnumerable<ProjectTask> Get()
        {
            return ProjectTasksRepository.GetAllProjectTasks();
        }

        // GET api/ptprojecttasks/5
        [Route("api/ptprojecttasks/{id?}")]
        public ProjectTask Get(int id)
        {
            return ProjectTasksRepository.GetProjectTask(id);
        }

        [Route("api/ptprojecttasks")]
        public IEnumerable<ProjectTask> Post(ProjectTask pt)
        {
            return ProjectTasksRepository.InsertProjectTask(pt);
        }

        [Route("api/ptprojecttasks")]
        public IEnumerable<ProjectTask> Put(ProjectTask pt)
        {
            return ProjectTasksRepository.UpdateProjectTask(pt);
        }

        [Route("api/ptprojecttasks")]
        public IEnumerable<ProjectTask> Delete(ProjectTask pt)
        {
            return ProjectTasksRepository.DeleteProjectTask(pt);
        }
    }
}
