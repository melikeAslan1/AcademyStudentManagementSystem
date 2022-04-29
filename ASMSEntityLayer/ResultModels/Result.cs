using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ResultModels
{
    public class Result : IResult
    {
        //diğer versiyonlar 
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Result(bool success)
        {
            IsSuccess = success;
        }

        // Extension metod
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }




        //public T Data { get; set; }
        //public int TotalCount { get; set; }

        //public Result(bool isSuccess, string message, T data, int totalCount)
        //{
        //    IsSuccess = isSuccess;
        //    Message = message;
        //    Data = data;
        //    TotalCount = totalCount;
        //}

        //public Result(bool isSuccess, string message, T data)
        //  : this(isSuccess, message, data, 0)
        //{

        //}
        //public Result(bool isSuccess, string message)
        //  : this(isSuccess, message, default(T))
        //{

        //}


    }
}
