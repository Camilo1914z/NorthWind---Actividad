using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.UseCases.Common.Ports;

namespace NorthWind.Presenters
{
    public interface IPresenter<ResponseType, FormatTYpe> : IOutputPort<ResponseType>
    {
        public FormatTYpe Content { get;  }
    }
}
