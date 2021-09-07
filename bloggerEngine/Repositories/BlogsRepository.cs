namespace bloggerEngine.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Blog Create(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs
            (title, body, imgUrl, published, creatorId)
            VALUES
            (@Title, @Body, @ImgUrl, @Published, @CreatorId);
            SELECT LAST_INSERT_ID;
            ";
            int id = _db.ExecuteScalar<int>(sql, newBlog)
            return GetById(id);
        }

        internal Blog GetAll(){
            string sql = @"
            SELECT
                a.*,
                b.*
            FROM blogs b
            JOIN accounts a ON a.id = b.creatorId
            ";
            return _db.Query<Profile, Blog, Blog>(sql, (profile, blog)=> {
                blog.Creator = profile;
                return blog;
            }, splitOn: "id").ToList<Blog>();
        }

        internal Blog GetAll(string creatorId){
            string sql = @"
            SELECT
                a.*,
                b.*
            FROM blogs b
            JOIN accounts a ON a.id = b.creatorId
            WHERE a.creatorId = @creatorId
            ";
            return _db.Query<Profile, Blog, Blog>(sql, (profile, blog)=> {
                blog.Creator = profile;
                return blog;
            }, splitOn: "id").ToList<Blog>();
        }

        internal Blog GetById(int id){
            string sql = @"
            SELECT
                b.*
            FROM blogs b
            JOIN accounts a ON a.id = b.creatorId
            WHERE b.id = @id;
            ";
            return _db.Query<Profile, Blog, Blog>(sql, (profile, blog)=> {
                blog.Creator = profile;
                return blog;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal Blog Update(Blog original){
            string sql = @"
            SELECT
                title = @Title,
                body = @Body,
                imgUrl = @ImgUrl,
                published = @Published
            WHERE b.id = @id;
            ";
            return _db.Execute(sql, original)
        }

        internal void Delete(int id)
        {
            string swl = "Delete FROM blogs WHERE id = @id LIMIT 1";
            _db.Execute(sql, new {id} );
        }
    }
}