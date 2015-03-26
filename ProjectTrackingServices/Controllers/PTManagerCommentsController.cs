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
    public class PTManagerCommentsController : ApiController
    {
        // GET api/ptmanagercomments
        [Route("api/ptmanagercomments")]
        public IEnumerable<ManagerComment> Get()
        {
            return ManagerCommentsRepository.GetAllManagerComments();
        }

        // GET api/ptmanagercomments/5
        [Route("api/ptmanagercomments/{id?}")]
        public ManagerComment Get(int id)
        {
            return ManagerCommentsRepository.GetManagerComment(id);
        }

        [Route("api/ptmanagercomments")]
        public IEnumerable<ManagerComment> Post(ManagerComment comment)
        {
            return ManagerCommentsRepository.InsertManagerComments(comment);
        }

        [Route("api/ptmanagercomments")]
        public IEnumerable<ManagerComment> Put(ManagerComment comment)
        {
            return ManagerCommentsRepository.UpdateManagerComments(comment);
        }

        [Route("api/ptmanagercomments")]
        public IEnumerable<ManagerComment> Delete(ManagerComment comment)
        {
            return ManagerCommentsRepository.DeleteManagerComments(comment);
        }
    }
}
