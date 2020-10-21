using System;
using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Domain.Repositories;

namespace Instagram.Services.Newsfeed.Services
{
    public class NewsfeedService : INewsfeedService
    {
        private readonly INewsfeedRepository _newsfeedRepository;

        public NewsfeedService(INewsfeedRepository newsfeedRepository)
        {
            _newsfeedRepository = newsfeedRepository;
        }

        public async Task UpdateNewsfeedAsync()
        {
            await _newsfeedRepository.UpdateNewsfeedAsync();
        }
    }
}