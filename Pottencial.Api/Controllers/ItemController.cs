using Microsoft.AspNetCore.Mvc;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.ItemCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers;
using Pottencial.Domain.Repositories;

namespace Pottencial.Api.Controllers;

[ApiController]
public class ItemController : ControllerBase
{
    [HttpPost("v1/item")]
    public async Task<GenericCommandResult> CreateItemAsync(
        [FromBody] CreateItemCommand command,
        [FromServices] ItemHandler handler)
    {
        return await handler.Handle(command);
    }

    [HttpGet("v1/item")]
    public async Task<List<Item>> GetAllItemAsync(
        [FromServices] IItemRepository repository,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        return await repository.GetAll(page, pageSize);
    }

    [HttpGet("v1/item/{id:guid}")]
    public async Task<GenericCommandResult> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] ItemHandler handler)
    {
        return await handler.Handle(id);
    }

    [HttpPut("v1/item")]
    public async Task<GenericCommandResult> UpdateItemAsync(
        [FromBody] UpdateItemCommand command,
        [FromServices] ItemHandler handler)
    {
        return await handler.Handle(command);
    }

    [HttpDelete("v1/item/{id}")]
    public async Task<GenericCommandResult> DeleteItemAsync(
        [FromRoute] DeleteItemCommand command,
        [FromServices] ItemHandler handler)
    {
        return await handler.Handle(command);
    }
}