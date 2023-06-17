using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 權限維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        /// <summary>
        /// 取得權限
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetPermissionList()
        {
            return Ok();
        }

        /// <summary>
        /// 新增權限
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddPermission()
        {
            return Ok();
        }

        /// <summary>
        /// 更新權限
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult UpdatePermission()
        {
            return Ok();
        }

        /// <summary>
        /// 刪除權限
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeletePermission()
        {
            return Ok();
        }
    }
}