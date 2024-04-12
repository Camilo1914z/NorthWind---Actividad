using NorthWind.UseCasesDTOs.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.UseCases.Common.Ports;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams RequestData { get ; }

        public IOutputPort<int> OutputPort { get; }
        public CreateOrderInteractor(CreateOrderParams requestData,
            IOutputPort<int> outputPort) => 
            (RequestData, OutputPort) = (requestData, outputPort);
       
    }
}