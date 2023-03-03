using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoleService _roleService;


        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _roleService.GetAllByRoleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Role role)
        {
            var result = _roleService.Add(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("RoleAndRoleMenuAdd")]
        public IActionResult RoleAndRoleMenuAdd(Role role)
        {
            var result = _roleService.RoleAndRoleMenuAdd(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Role role)
        {
            var result = _roleService.Update(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var getData = _roleService.GetById(id);
            var result = _roleService.DeleteRoleAndRoleMenu(getData.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
