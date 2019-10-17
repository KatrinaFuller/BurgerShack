using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Item> Get()
    {
      return _repo.Get();
    }

    public Item Get(string id)
    {
      Item exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public Item Create(Item newItem)
    {
      newItem.Id = Guid.NewGuid().ToString();
      _repo.Create(newItem);
      return newItem;
    }

    public Item Edit(Item newItem)
    {
      Item item = _repo.Get(newItem.Id);
      if (item == null)
      {
        throw new Exception("Invalid Id");
      }
      item.Name = newItem.Name;
      item.Description = newItem.Description;
      item.Price = newItem.Price;
      _repo.Edit(item);
      return item;
    }

    public string Delete(string id)
    {
      Item item = _repo.Get(id);
      if (item == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Successfully deleted";
    }
  }
}