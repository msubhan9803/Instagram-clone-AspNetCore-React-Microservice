using System.Threading.Tasks;

namespace Instagram.Services.Newsfeed.Hubs.Client
{
    public interface INewsfeedClient
    {
        Task FetchNewsfeed();
    }
}