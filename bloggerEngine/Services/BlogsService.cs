namespace bloggerEngine.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo

        internal Blog Create(Blog newBlog)
        {
            Blog created = _repo.Create(newBlog);
            return created;
        }

        internal List<Blog> GetBlogsByCreator(string creatorId, bool careIfPublished = true)
        {
            List<Blog> blogs = _repo.GetAll(string creatorId);
            if (careIfPublished){

            }
            return blogs
        }

        internal Blog Get(int id, bool checkPublished = true)
        {
            Blog blog = _repo.GetById(id);
            if (blog == null || (checkPublished && blog.Published == false ))
            {
                throw new Exception("Invalid Id");
            }
            return blog;
        }

        internal List<Blog> Get()
        {
            List<Blog> blogs = _repo.GetAll();
            return blogs.FindAll( b => b.Published == true);
        }

        internal Blog Delete(int blogId, string userId)
        {
            // FIXME
            Blog blogToDelete = _repo.Get(int blogId, string userId);
            return
        }

        internal Blog Update(Blog editedBlog)
        {

            Blog original = Get(editedBlog.Id, false);
            if(original.CreatorId != editedBlog.CreatorId)
            {
                throw new Exception("Invalid Access");
            }
            original.Body = editedBlog.Body.Length > 0 ? editedBlog.Body: original.Body;
            original.Title = editedBlog.Title.Length > 0 ? editedBlog.Body: original.Body;
            // NULL coalescing: if the value is null dont drill
            original.ImgUrl = editedBlog.ImgUrl?.Length? > 0 ? editedBlog.ImgUrl: original.ImgUrl;
            original.Published = editedBlog.Published != null ? editedBlog.Published: original.Published;
            return _repo.Update(original);
        }
    }
}