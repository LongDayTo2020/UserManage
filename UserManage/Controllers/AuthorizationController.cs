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
    /// 角色權限維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// 取得角色授權
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetAuthorizationList() => Ok(_authorizationService.GetAll().ToList());

        /// <summary>
        /// 新增角色授權
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddAuthorization([FromBody] RequestAuthorization request) =>
            Ok(_authorizationService.Add(request));

        /// <summary>
        /// 更新角色授權
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id:int}")]
        public IActionResult UpdateAuthorization([FromRoute] int id, [FromBody] RequestAuthorization request) =>
            Ok(_authorizationService.Update(id, request));


        /// <summary>
        /// 刪除角色授權
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeleteAuthorization([FromRoute] int id) => Ok(_authorizationService.Delete(id));
    }
}