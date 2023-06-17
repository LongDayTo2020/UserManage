using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManage.Controllers
{
    /// <summary>
    /// 驗證操作
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
            
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Register()
        {
            return Ok();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Login()
        {
            return Ok();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}