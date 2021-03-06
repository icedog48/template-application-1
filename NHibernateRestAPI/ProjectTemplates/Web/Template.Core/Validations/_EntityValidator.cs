﻿using FluentValidation;
using FluentValidation.Results;
using Template.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Validations
{
    public abstract class _EntityValidator<TEntity> : AbstractValidator<TEntity> where TEntity : _Entity
    {
        public new ValidationResult Validate(TEntity instance)
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
