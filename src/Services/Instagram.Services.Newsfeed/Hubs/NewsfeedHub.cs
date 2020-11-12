using Instagram.Services.Newsfeed.Hubs.Client;
using Microsoft.AspNetCore.SignalR;

namespace Instagram.Services.Newsfeed.Hubs
{
    public class NewsfeedHub : Hub<INewsfeedClient>
    {
        
    }
}