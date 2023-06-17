using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 會員維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 取得會員
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetUserList()
        {
            return Ok();
        }

        /// <summary>
        /// 新增會員
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddUser()
        {
            return Ok();
        }

        /// <summary>
        /// 更新會員
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult UpdateUser()
        {
            return Ok();
        }

        /// <summary>
        /// 刪除會員
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteUser()
        {
            return Ok();
        }
    }
}