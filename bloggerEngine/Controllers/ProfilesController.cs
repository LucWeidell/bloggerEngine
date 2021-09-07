namespace bloggerEngine.Controllers
{
    public class ProfilesController
    {
        private readonly BlogsService _bs;
        private readonly AccountService _acs;

        public ProfilesController(BlogsService blogsService, AccountService accountService)
        {
            _bs = blogsService
            _acs = accountService;
        }

        [HttpGet("{id}/blogs")]
        public ActionResult<List<Blog>> GetBlogs(string id)
        {
            try
            {
                List<Blog> blogs = _bs.GetBlogsByCreator(id);
                return blogs;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                Profile profile = _acs.GetById(id);
                return Ok(profile);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}