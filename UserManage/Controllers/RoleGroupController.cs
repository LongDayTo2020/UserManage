using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Repository;
using UserManage.Service.Service;

namespace UserManage.Controllers
{
    /// <summary>
    /// 角色歸類群組
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupController : ControllerBase
    {
        private readonly IRoleGroupService _roleGroupService;

        public RoleGroupController(IRoleGroupService roleGroupService)
        {
            _roleGroupService = roleGroupService;
        }

        /// <summary>
        /// 取得角色群組
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetRoleGroupList()
            => Ok(_roleGroupService.GetAll().ToList());

        /// <summary>
        /// 新增角色群組
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRoleGroup([FromBody] RequestRoleGroup request)
            => Ok(_roleGroupService.Add(request));

        /// <summary>
        /// 更新角色群組
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id:int}")]
        public IActionResult UpdateRoleGroup([FromRoute] int id, [FromBody] RequestRoleGroup request)
            => Ok(_roleGroupService.Update(id, request));

        /// <summary>
        /// 刪除角色群組
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeleteRoleGroup([FromRoute] int id)
            => Ok(_roleGroupService.Delete(id));
    }
}