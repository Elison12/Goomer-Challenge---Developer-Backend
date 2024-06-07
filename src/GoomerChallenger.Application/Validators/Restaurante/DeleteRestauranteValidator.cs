using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Validators.Restaurante
{
    public class DeleteRestauranteValidator : AbstractValidator<DeleteRestauranteRequest>
    {
        public DeleteRestauranteValidator ()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A requisição não pode ser vazia.");
            RuleFor(x => x.idRestaurenteRequest)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("O id passado precisa ser maior ou igual a zero.");
        }
    }
}
