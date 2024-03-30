using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHanlderBase , IExceptionHandler
    {
        
        public Task Handle(ExceptionContext context)
        {

            var Exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError,
                Exception.Message, Exception.Detail);
        }
    }
}
