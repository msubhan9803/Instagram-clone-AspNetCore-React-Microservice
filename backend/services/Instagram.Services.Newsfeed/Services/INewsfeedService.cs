using System;
using System.Threading.Tasks;

namespace Instagram.Services.Newsfeed.Services
{
    public interface INewsfeedService
    {
        Task UpdateNewsfeedAsync();
    }
}