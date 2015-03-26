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
    public class PTProjectsController : ApiController
    {
        ProjectsRepository repository;

        public PTProjectsController()
        {
            repository = new ProjectsRepository();
        }

        // GET api/projects
        [Route("api/ptprojects")]
        public IEnumerable<Project> Get()
        {
            return repository.GetAllProjects();
        }

        // GET api/projects/5
        [Route("api/ptprojects/{id?}")]
        public Project Get(int id)
        {
            return repository.GetProject(id);
        }

        [Route("api/ptprojects/{name:alpha}")]
        public IEnumerable<Project> Get(string name)
        {
            return repository.GetProjectByName(name);
        }

        [Route("api/ptprojects")]
        public IEnumerable<Project> Post(Project p)
        {
            return repository.InsertProject(p);
        }

        [Route("api/ptprojects/{id}")]
        public IEnumerable<Project> Put([FromBody]Project p)
        {
            return repository.UpdateProject(p);
        }

        [Route("api/ptprojects/{id}")]
        [HttpDelete]
        public IEnumerable<Project> Delete(int id)
        {
            return repository.DeleteProject(id);
        }
    }
}
