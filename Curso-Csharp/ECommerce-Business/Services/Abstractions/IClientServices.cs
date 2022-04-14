using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Abstractions
{
    interface IClientServices
    {
        public void AddCart(Cart cart);
        public void DeleteProductInCart(int id, Cart cart);
    }
}
