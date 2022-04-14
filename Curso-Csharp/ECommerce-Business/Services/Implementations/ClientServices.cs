using ECommerce_Business.Services.Abstractions;
using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Business.Services.Implementations
{
    public class ClientServices : IClientServices
    {
        private List<Cart> _carts = new List<Cart>();
        private List<SellOrder> _sellOrders = new List<SellOrder>();
        public void AddCart(Cart cart) => _carts.Add(cart);
        public Cart GetCart(string clientName) => _carts.FirstOrDefault(c => c.ClientName == clientName);
        public List<Cart> GetCarts() => _carts;
        public void AddSellOrder(SellOrder so) => _sellOrders.Add(so);
        public SellOrder GetSellOrder(string clientName) => _sellOrders.FirstOrDefault(c => c.ClientName == clientName);
        public List<SellOrder> GetSellOrders() => _sellOrders;

        public void DeleteProductInCart( int id, Cart cart)
        {
            try
            {
                var product = cart.ProductsInCart.FirstOrDefault(p => p.Id == id);
                if (product != null)
                    cart.ProductsInCart.Remove(product);
                else
                    throw new InvalidOperationException("No Delete");
            }
            catch (Exception e)
            {
                e = new InvalidOperationException("No Delete");
                throw;
            }
        }
    }
}
