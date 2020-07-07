using System;

namespace Instagram.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserId { get; set; }
    }
}