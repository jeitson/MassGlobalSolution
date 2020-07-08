using Library_MG;
using Library_MG.Src.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace API_MG.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployee employeeModule;
        public EmployeeController(IEmployee employee)
        {
            employeeModule = employee;
        }

        [HttpGet]
        [Route("api/employee/{id}/list")]
        public async Task<HttpResponseMessage> List(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await employeeModule.GetAsync(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
