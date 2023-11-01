using KP_ManageUsers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace KP_ManageUsers.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUsersController : Controller
    {
        private readonly IManageUsersService _service;

        public ManageUsersController(IManageUsersService service)
        {
            _service = service;
        }

        [HttpGet("GetAccessGroups")]
        public async Task<List<AccessGroup>> GetAccessGroups()
        {
            return await _service.GetAccessGroups();
        }
        
        [HttpGet("GetUserGroups")]
        public async Task<List<UserGroup>> GetUserGroups()
        {
            return await _service.GetUserGroups();
        }

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _service.GetUsers();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.CreateUser(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("CreateUserGroup")]
        public async Task<ActionResult> CreateUserGroup([FromBody] UserGroup model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.CreateUserGroup(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.UpdateUser(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateUserGroup")]
        public async Task<IActionResult> UpdateUserGroup([FromBody] UserGroup model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.UpdateUserGroup(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                await _service.DeleteUser(id);
                return NoContent();
            }
            else
            { return BadRequest(ModelState); }
        }

        [HttpDelete]
        [Route("DeleteUserGroup")]
        public async Task<IActionResult> DeleteUserGroup([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                await _service.DeleteUserGroup(id);
                return NoContent();
            }
            else
            { return BadRequest(ModelState); }
        }
    }
}
