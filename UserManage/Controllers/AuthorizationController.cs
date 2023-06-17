using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 角色權限維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        /// <summary>
        /// 取得角色授權
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetAuthorizationList()
        {
            return Ok();
        }

        /// <summary>
        /// 新增角色授權
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddAuthorization()
        {
            return Ok();
        }

        /// <summary>
        /// 更新角色授權
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult UpdateAuthorization()
        {
            return Ok();
        }

        /// <summary>
        /// 刪除角色授權
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteAuthorization()
        {
            return Ok();
        }
    }
}