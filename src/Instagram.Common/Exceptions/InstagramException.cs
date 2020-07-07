using System;

namespace Instagram.Common.Exceptions
{
    public class InstagramException : Exception
    {
        public string Code { get; }

        public InstagramException()
        {
        }

        public InstagramException(string code)
        {
            Code = code;
        }

        public InstagramException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public InstagramException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public InstagramException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public InstagramException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}