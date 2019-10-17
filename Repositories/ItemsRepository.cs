using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class ItemsRepository
  {

    private readonly IDbConnection _db;
    public ItemsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Item> Get()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Item>(sql);
    }

    public Item Get(string id)
    {
      string sql = "SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    public void Create(Item newItem)
    {
      string sql = @"
      INSERT INTO items
      (id, name, description, price)
      VALUES
      (@Id, @Name, @Description, @Price)";
      _db.Execute(sql, newItem);
    }

    public void Edit(Item item)
    {
      string sql = @"
      UPDATE items
      SET
        name = @Name
        description = @Description
        price = @Price
    WHERE id = @id";
      _db.Execute(sql, item);
    }

    public void Delete(string id)
    {
      string sql = "DELETE FROM items WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}