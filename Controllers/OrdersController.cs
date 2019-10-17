using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]

  public class OrdersController : ControllerBase
  {
    private readonly OrdersService _ordersService;
    public OrdersController(OrdersService ordersService)
    {
      _ordersService = ordersService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
      try
      {
        return Ok(_ordersService.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
      try
      {
        return Ok(_ordersService.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/items")]
    public ActionResult<Order> GetItems(int id)
    {
      try
      {
        return Ok(_ordersService.GetItems(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Order> Create([FromBody] Order newOrder)
    {
      try
      {
        return Ok(_ordersService.Create(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Order> Edit([FromBody] Order newOrder, int id)
    {
      try
      {
        newOrder.Id = id;
        return Ok(_ordersService.Edit(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/addItem")]
    public ActionResult<string> AddItemToOrder([FromBody] Item item, int id)
    {
      try
      {
        return Ok(_ordersService.AddItemToOrder(id, item.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/removeItem")]
    public ActionResult<string> RemoveItemFromOrder([FromBody] ItemOrder itemOrder, int id)
    {
      try
      {
        itemOrder.OrderId = id;
        return Ok(_ordersService.RemoveItemFromOrder(itemOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ordersService.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}