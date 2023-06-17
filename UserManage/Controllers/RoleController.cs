using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 角色維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        
        #region CRUD USER

        /// <summary>
        /// 取得角色
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetRoleList()
        {
            return Ok();
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRole()
        {
            return Ok();
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult UpdateRole()
        {
            return Ok();
        }

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteRole()
        {
            return Ok();
        }

        #endregion

    }
}