using System.Collections.Generic;

namespace Instagram.Common.DTOs.Post
{
    public class ErrorResponse
    {        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}