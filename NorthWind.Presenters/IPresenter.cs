using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public interface IPresenter< FormatDataTYpe>
    {
        public FormatDataTYpe Content { get;  }
    }
}
