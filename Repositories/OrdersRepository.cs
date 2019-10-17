using System;
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class OrdersRepository
  {
    internal IEnumerable<Order> Get()
    {
      throw new NotImplementedException();
    }

    internal Order Get(int orderId)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Item> GetItemsByOrderId(int orderId)
    {
      throw new NotImplementedException();
    }

    internal int Create(Order newOrder)
    {
      throw new NotImplementedException();
    }

    internal void Edit(Order order)
    {
      throw new NotImplementedException();
    }

    internal void AddItemToOrder(int id, string itemId)
    {
      throw new NotImplementedException();
    }

    internal ItemOrder GetItemOrder(ItemOrder itemOrder)
    {
      throw new NotImplementedException();
    }

    internal void RemoveItemFromOrder(int id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}