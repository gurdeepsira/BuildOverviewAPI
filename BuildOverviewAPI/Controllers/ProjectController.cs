using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octopus.Client;
using Octopus.Client.Model;

namespace BuildOverviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        public string server
        { get; set; }

        public string apiKey
        { get; set; }


        [HttpGet]
        [Route("api/{ProjectController}")]
        [ActionName("GetOctopusDetails")]
        public void GetOctopusDetails(string projectName)
        {
            var endpoint = new OctopusServerEndpoint(server, apiKey);

            using (var client = OctopusAsyncClient.Create(endpoint))
            {

                Task<ProjectResource> project = null;

                try
                {
                    project = client.Result.Repository.Projects.FindByName(projectName);

                  
                }

                catch (Exception ex)
                {

                }

                finally
                {
                    project.Dispose();
                }
               

               
            }

        }
    }
}