using System;

namespace Instagram.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);     
    }
}