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
    [Route("/api/[controller]")]

    public class BlogsController
    {
        private readonly BlogsService _bs;


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
        {
            try
            {
                 Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                 newBlog.CreatorId = userInfo.Id;
                 Blog created = _bs.Create(newblog);
                 return Ok(created);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Blog>> Update(int id, [FromBody] Blog update)
        {
            try
            {
                 Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                 update.CreatorId = userInfo.Id;
                 update.Id = id;
                 Blog newBlog = _bs.Update(update);
                 return Ok(newBlog);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Blog>> Get()
        {
            try
            {
                List<Blog> created = _bs.Get();
                return Ok(created);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            try
            {
                Blog blog = _bs.Get(id);
                return Ok(blog);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        public Task<ActionResult<Blog>> Delete(int id)
        {
            // FIXME
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                update.CreatorId = userInfo.Id;
                update.Id = id;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}