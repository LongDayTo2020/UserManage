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
    /// 權限維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// 取得權限
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetPermissionList()
            => Ok(_permissionService.GetAll().ToList());

        /// <summary>
        /// 新增權限
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddPermission([FromBody] RequestPermission request)
            => Ok(_permissionService.Add(request));

        /// <summary>
        /// 更新權限
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id:int}")]
        public IActionResult UpdatePermission([FromRoute] int id, [FromBody] RequestPermission request)
            => Ok(_permissionService.Update(id, request));

        /// <summary>
        /// 刪除權限
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeletePermission([FromRoute] int id)
            => Ok(_permissionService.Delete(id));
    }
}