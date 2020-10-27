using System.Threading.Tasks;

namespace Instagram.Services.Newsfeed.Jobs
{
    public interface INewsfeedUpdateJob
    {
        Task UpdateNewsfeedAsync();
    }
}