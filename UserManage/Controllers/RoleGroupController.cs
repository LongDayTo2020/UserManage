using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 角色歸類群組
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupController : ControllerBase
    {
        /// <summary>
        /// 取得角色群組
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetRoleGroupList()
        {
            return Ok();
        }

        /// <summary>
        /// 新增角色群組
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRoleGroup()
        {
            return Ok();
        }

        /// <summary>
        /// 更新角色群組
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult UpdateRoleGroup()
        {
            return Ok();
        }

        /// <summary>
        /// 刪除角色群組
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteRoleGroup()
        {
            return Ok();
        }
    }
}
