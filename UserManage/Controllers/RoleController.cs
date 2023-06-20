using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManage.Library.ViewModel.Request;
using UserManage.Service.Service;

namespace UserManage.Controllers
{
    /// <summary>
    /// 角色維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 取得角色
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetRoleList() => Ok(_roleService.GetAll().ToList());

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRole([FromBody] RequestRole request) => Ok(_roleService.Add(request));

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id:int}")]
        public IActionResult UpdateRole([FromRoute] int id, [FromBody] RequestRole request) =>
            Ok(_roleService.Update(id, request));

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeleteRole([FromRoute] int id) => Ok(_roleService.Delete(id));
    }
}