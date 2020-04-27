using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkz_school_service.Models.Communication
{
    public class ResponseBase
    {
        public const string IS_SUCCESS_PARAMETER = "@V_IS_SUCCESS";
        public const string STATUS_CODE_PARAMETER = "@V_STATUS_CODE";
        public const string STATUS_MESSAGE_PARAMETER = "@V_STATUS_MESSAGE";
        public const string GENERATED_ID_PARAMETER = "@V_GENERATED_ID";


        public bool IsSuccess { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
