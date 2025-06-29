﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.System.Users;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Authencate(request);

            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ApiErrorResult<bool>("Bạn không có quyền truy cập"));
            }

            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequets request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ApiErrorResult<bool>("Bạn không có quyền truy cập"));
            }

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result= await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetUserPaging([FromQuery] GetUserPagingRequest request)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ApiErrorResult<bool>("Bạn không có quyền truy cập"));
            }

            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ApiErrorResult<bool>("Bạn không có quyền truy cập"));
            }

            var users = await _userService.GetById(id);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ApiErrorResult<bool>("Bạn không có quyền truy cập"));
            }

            var result = await _userService.Delete(id);
            return Ok(result);
        }
    }
}
