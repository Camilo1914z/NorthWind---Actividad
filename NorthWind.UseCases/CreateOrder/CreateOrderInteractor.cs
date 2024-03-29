using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOFWork UnitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOFWork unitOfWork) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);
        public async Task<int> Handle(CreateOrderInputPort request,
            CancellationToken cancellationToken)
        {
            Order Order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPotalCode,
                ShippingType = Entities.Enums.ShippingTypes.Road,
                DiscounType = Entities.Enums.DiscountTypes.Percentage,
                Discount = 10
            };
            OrderRepository.create(Order);
            foreach (var item in request.OrderDetails)
            {
                OrderDetailRepository.Create(
                new OrderDetail {
                    Order = Order,
                    ProductID=item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    
                
                });




            }
            try
            
                {
                    await UnitOfWork.SaveChangesAsync();
                }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la Orden.",
                    ex.Message);
            }
            return Order.Id;
        }

        }
       
    }
