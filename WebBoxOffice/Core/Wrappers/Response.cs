using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBoxOffice.Core.Wrappers
{
    /// <summary>
    /// Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Response()
        {
        }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="data"></param>
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// status Response
        /// </summary>
        public bool Succeeded { get; set; }
        /// <summary>
        /// Errors
        /// </summary>
        public string[] Errors { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
