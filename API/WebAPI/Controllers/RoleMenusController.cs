using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleMenusController : ControllerBase
    {
     private readonly IRoleMenuService _roleMenuService;

        public RoleMenusController(IRoleMenuService roleMenuService)
        {
            _roleMenuService = roleMenuService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roleMenuService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetAllRoleMenu")]
        public IActionResult GetAllRoleMenu()
        {
            var result = _roleMenuService.GetAllRoleMenu();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllByRoleId")]
        public IActionResult GetAllByRoleId(int id)
        {
            var result = _roleMenuService.GetAllByRoleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlist")]
        public IActionResult AddList(List<RoleMenu> roleMenuList)
        {
            var result = _roleMenuService.AddList(roleMenuList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("updateAll")]
        public IActionResult UpdateAll(List<RoleMenu> roleMenuList)
        {
            var result = _roleMenuService.UpdateAll(roleMenuList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}