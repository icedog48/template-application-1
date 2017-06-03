﻿using Core.Models;
using Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Default
{
    public class DefaultService<TEntity> : IService<TEntity> where TEntity : _Entity
    {
        private readonly IRepository<TEntity> repository;

        private readonly AbstractValidator<TEntity> validator;

        public DefaultService(IRepository<TEntity> repository, AbstractValidator<TEntity> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public TEntity Get(int id)
        {
            return this.repository.Get(id);
        }

        public void Remove(TEntity entity)
        {
            this.validator.ValidateAndThrow(entity, ruleSet: "remove");

            this.repository.Remove(entity);
        }

        public void Save(TEntity entity)
        {
            var ruleSet = (entity.Id == 0) ? "add" : "update";

            this.validator.ValidateAndThrow(entity, ruleSet: ruleSet);

            this.repository.Save(entity);
        }
    }
}