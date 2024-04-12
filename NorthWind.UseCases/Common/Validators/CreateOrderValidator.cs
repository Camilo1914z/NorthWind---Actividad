using FluentValidation;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderParams>
    {
        public CreateOrderValidator()
        {



            RuleFor(c => c.CustomerId).NotEmpty()
                .WithMessage("Debe proporciornar la identificacion del cliente");
            RuleFor(c => c.ShipAddress).NotEmpty()
                .WithMessage("Debe proporcionar un correo de envio");
            RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar por lo menos 3 letras de la ciudades");
            RuleFor(c => c.ShipCountry).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar por lo menos 3 caracteres del pais");
            RuleFor(c => c.OrderDetails)
                .Must(d => d != null && d.Any())
                .WithMessage("Debe especificar los productos de la orden");
        }


    }
}
