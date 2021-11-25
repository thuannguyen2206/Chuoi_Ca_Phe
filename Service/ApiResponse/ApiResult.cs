using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ApiResponse
{
    public class ApiResult<T>
    {
        public ApiResult() { }

        public ApiResult(bool success)
        {
            this.Success = success;
        }

        public ApiResult(bool success, T data)
        {
            this.Success = success;
            this.Data = data;
        }

        public ApiResult(bool success, string errorCode)
        {
            this.Success = success;
            this.ErrorCode = errorCode;
        }

        public ApiResult(bool success, T data, string errorCode)
        {
            this.Success = success;
            this.Data = data;
            this.ErrorCode = errorCode;
        }

        public bool Success { get; set; }

        public string ErrorCode { get; set; }

        public T Data { get; set; }
    }
}
