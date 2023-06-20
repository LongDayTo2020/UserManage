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
    /// 角色群組分類維護
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupClassifyController : ControllerBase
    {
        private readonly IRoleGroupClassifyService _roleGroupClassifyService;

        public RoleGroupClassifyController(IRoleGroupClassifyService roleGroupClassifyService)
        {
            _roleGroupClassifyService = roleGroupClassifyService;
        }

        /// <summary>
        /// 取得角色群組分類
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetRoleGroupClassifyList() => Ok(_roleGroupClassifyService.GetAll());

        /// <summary>
        /// 新增角色群組分類
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRoleGroupClassify([FromBody] RequestRoleGroupClassify request) =>
            Ok(_roleGroupClassifyService.Add(request));

        /// <summary>
        /// 刪除角色群組分類
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult DeleteRoleGroupClassify([FromBody] RequestRoleGroupClassify request)
            => Ok(_roleGroupClassifyService.Delete(request));
    }
}