﻿using Menu.Domain.Contracts.Application;
using Menu.Domain.Entities;
using Menu.Domain.Contracts;
using Menu.Domain.Dto;

namespace Menu.Application
{
    public class IngredientApplication : ApplicationBase<IngredientModel, Ingredient>, IIngredientApplication
    {
        public IngredientApplication(IMenuContext context)
            : base(context)
        {
        }
    }
}
