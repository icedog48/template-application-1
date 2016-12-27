using FluentValidation;
using FluentValidation.Results;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public abstract class _EntityValidator<TEntity> : AbstractValidator<TEntity> where TEntity : _Entity
    {
        public override ValidationResult Validate(TEntity instance)
        {
            if (instance == null)
            {
                var validationResult = new ValidationResult(new[] { new ValidationFailure("", "Instance cannot be null") });

                return validationResult;
            }

            return base.Validate(instance);
        }
    }
}
