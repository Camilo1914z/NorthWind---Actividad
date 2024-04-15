using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {


        readonly ICreateOrderInputPort InputPort;
        //readonly ICreateOrderOutputPort OutputPort;
        readonly IPresenter<string> Presenter;
        public OrderController(ICreateOrderInputPort inputPort, IPresenter<string> presenter) =>
            (InputPort, Presenter) =(inputPort,presenter);
        [HttpPost("Create-order")]

        public async Task<string> CreateOrder(CreateOrderParams orderparams)
        {
            await InputPort.Handle(orderparams);
            return Presenter.Content;
        }

    }
}
