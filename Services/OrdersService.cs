using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class OrdersService
  {
    private readonly OrdersRepository _repo;
    private readonly ItemsRepository _itemRepo;

    public OrdersService(OrdersRepository repo, ItemsRepository itemRepo)
    {
      _repo = repo;
      _itemRepo = itemRepo;
    }

    public IEnumerable<Order> Get()
    {
      return _repo.Get();
    }

    public Order Get(int id)
    {
      Order exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public IEnumerable<Item> GetItems(int orderId)
    {
      Order order = _repo.Get(orderId);
      if (order == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetItemsByOrderId(orderId);
    }

    public Order Create(Order newOrder)
    {
      int id = _repo.Create(newOrder);
      newOrder.Id = id;
      return newOrder;
    }

    public Order Edit(Order newData)
    {
      Order order = _repo.Get(newData.Id);
      if (order == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Edit(order);
      return order;
    }

    public string AddItemToOrder(int id, string itemId)
    {
      Order order = _repo.Get(id);
      if (order == null)
      {
        throw new Exception("Invalid Order");
      }
      Item itemToAdd = _itemRepo.Get(itemId);
      if (itemToAdd == null)
      {
        throw new Exception("Invalid item");
      }
      _repo.AddItemToOrder(id, itemId);
      return "Successfully added Item to Order";

    }

    public string RemoveItemFromOrder(ItemOrder itemOrder)
    {
      ItemOrder exists = _repo.GetItemOrder(itemOrder);
      if (exists == null)
      {
        throw new Exception("Invalid info");
      }
      _repo.RemoveItemFromOrder(exists.Id);
      return "Successfully removed";
    }

    public string Delete(int id)
    {
      Order order = _repo.Get(id);
      if (order == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Successfully deleted";
    }
  }
}