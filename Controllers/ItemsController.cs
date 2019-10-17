using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly ItemsService _itemsService;
    public ItemsController(ItemsService itemsService)
    {
      _itemsService = itemsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
      try
      {
        return Ok(_itemsService.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(string id)
    {
      try
      {
        return Ok(_itemsService.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Item> Create([FromBody] Item newItem)
    {
      try
      {
        return Ok(_itemsService.Create(newItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Edit([FromBody] Item newItem, string id)
    {
      try
      {
        newItem.Id = id;
        return Ok(_itemsService.Edit(newItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        return Ok(_itemsService.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
