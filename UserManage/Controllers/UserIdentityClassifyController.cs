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
    /// 使用者歸類角色群組維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserIdentityClassifyController : ControllerBase
    {
        private readonly IUserIdentityClassifyService _userIdentityClassifyService;

        public UserIdentityClassifyController(IUserIdentityClassifyService userIdentityClassifyService)
        {
            _userIdentityClassifyService = userIdentityClassifyService;
        }

        /// <summary>
        /// 取得使用者歸類角色群組
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetUserRoleGroupList() => Ok(_userIdentityClassifyService.GetAll());
        
        /// <summary>
        /// 新增使用者歸類角色群組
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddUserRoleGroup([FromBody] RequestUserRoleGroup request) => Ok(_userIdentityClassifyService.Add(request));

        /// <summary>
        /// 刪除使用者歸類角色群組
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteUserRoleGroup([FromBody] RequestUserRoleGroup request) => Ok(_userIdentityClassifyService.Delete(request));
    }
}