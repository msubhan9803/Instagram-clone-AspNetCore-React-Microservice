using System.Collections.Generic;

namespace Instagram.Common.DTOs.User
{
    public class ErrorResponse
    {        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}