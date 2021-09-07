using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bloggerEngine.Models;
using bloggerEngine.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bloggerEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly BlogsService _blogsService;

        public AccountController(AccountService accountService, BlogsService blogsservice)
        {
            _accountService = accountService;
            _blogsService = blogsService
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{blogs}")]
        [Authorize]
        public async Task<ActionResult<List<Blog>> GetBlogs()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Blog> blogs = _bs.GetBlogsByCreator(userInfo.id, false)
                return Ok(blogs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}