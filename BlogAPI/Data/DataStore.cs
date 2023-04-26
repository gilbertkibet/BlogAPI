using BlogAPI.Entities;

namespace BlogAPI.Data
{
    public static class DataStore
    {
       public static List<Blog> listOfBlogs = new List<Blog>()
        {
            new Blog(){Id=1,Title="Blog One",Description="This is blog one"},
            new Blog(){Id=2,Title="Blog Two",Description="This is blog Two"}
        };
    }
}
