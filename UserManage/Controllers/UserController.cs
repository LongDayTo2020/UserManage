using Microsoft.AspNetCore.Mvc;
using UserManage.Library.ViewModel.Request;
using UserManage.Service.Service;

namespace UserManage.Controllers
{
    /// <summary>
    /// 會員維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 取得會員
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetUserList()
            => Ok(_userService.GetAll());

        /// <summary>
        /// 新增會員
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddUser([FromBody] RequestUser request)
            => Ok(_userService.Add(request));


        /// <summary>
        /// 更新會員
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id:int}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] RequestUser request) =>
            Ok(_userService.Update(id, request));

        /// <summary>
        /// 刪除會員
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
            => Ok(_userService.Delete(id));
    }
}