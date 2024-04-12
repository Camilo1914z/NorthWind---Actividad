using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {



            RuleFor(c => c.RequestData.CustomerId).NotEmpty()
                .WithMessage("Debe proporciornar la identificacion del cliente");
            RuleFor(c => c.RequestData.ShipAddress).NotEmpty()
                .WithMessage("Debe proporcionar un correo de envio");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar por lo menos 3 letras de la ciudades");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar por lo menos 3 caracteres del pais");
            RuleFor(c => c.RequestData.OrderDetails)
                .Must(d => d != null && d.Any())
                .WithMessage("Debe especificar los productos de la orden");
        }


    }
}
