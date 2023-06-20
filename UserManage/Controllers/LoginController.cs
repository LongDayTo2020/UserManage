using Microsoft.AspNetCore.Mvc;
using UserManage.Library.ViewModel.Request;
using UserManage.Service.Service;

namespace UserManage.Controllers
{
    /// <summary>
    /// 驗證操作
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogService _logService;

        public LoginController(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] RequestRegister request)
        {
            return Ok();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] RequestLogin request)
        {
            return Ok();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult Logout([FromBody] RequestLogout request)
        {
            return Ok();
        }
    }
}