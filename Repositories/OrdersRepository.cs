using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class OrdersRepository
  {
    private readonly IDbConnection _db;

    public OrdersRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Order> Get()
    {
      string sql = "SELECT * FROM orders";
      return _db.Query<Order>(sql);
    }

    public Order Get(int id)
    {
      string sql = "SELECT * FROM orders WHERE id = @id";
      return _db.QueryFirstOrDefault<Order>(sql, new { id });
    }

    public int Create(Order newOrder)
    {
      string sql = @"
      INSERT INTO orders
      (customerName)
      VALUES
      (@CustomerName);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newOrder); //getting the new id back and returning it
    }

    public void Edit(Order order)
    {
      string sql = @"
      UPDATE orders
      SET
        customerName = @CustomerName
    WHERE id = @Id";
      _db.Execute(sql, order);
    }
    public void Delete(int id)
    {
      string sql = "DELETE FROM orders WHERE id = $id";
      _db.Execute(sql, new { id });
    }

    public void AddItemToOrder(int orderId, string itemId)
    {
      string sql = @"
      INSERT INTO itemsorders
      (orderId, itemId)
      VALUES
      (@orderId, @itemId)";
      _db.Execute(sql, new { orderId, itemId });
    }

    public IEnumerable<Item> GetItemsByOrderId(int orderId)
    {
      string sql = @"
      SELECT * FROM itemsorders io
      INNER JOIN items ON i.id = io.itemId
      WHERE io.orderId = @orderId
      ";
      return _db.Query<Item>(sql, new { orderId });
    }

    public ItemOrder GetItemOrder(ItemOrder itemOrder)
    {
      string sql = "SELECT * FROM itemsorders WHERE orderId = @OrderId AND itemId = @ItemId";
      return _db.QueryFirstOrDefault<ItemOrder>(sql, itemOrder);
    }

    public void RemoveItemFromOrder(int id)
    {
      string sql = "DELETE FROM itemsorders WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}