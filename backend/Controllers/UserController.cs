using AdventureAdorn.API.Models;
using AdventureAdorn.API.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdventureAdorn.API.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUsersServices _formServices;
        public UserController(IUsersServices formServices) 
        {
            _formServices = formServices;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> login(Guid clientId)
        {
            //var form = JsonConvert.DeserializeObject<User>(Request.Form["model"][0]);
            string form=null;
            var formView = await _formServices.Login(clientId,form);
            return Ok(formView);
        }

        //[HttpGet]
        //[Route("GetAllVendors/{filter}")]
        //public async Task<IActionResult> GetAllVendors(Guid clientId, string filter)
        //{
        //    var result = (await _formServices.GetVendors(clientId, filter)).OrderBy(t => t.Name).ToArray();
        //    return Ok(result);
        //}
    }
}
