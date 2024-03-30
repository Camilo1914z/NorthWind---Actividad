using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWind.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(Exception context);
    }
}
