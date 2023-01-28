using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.OrderCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers;
using Pottencial.Domain.Repositories;
using Pottencial.Infra.Context;

namespace Pottencial.Api.Controllers;

[ApiController]
public class OrderController : ControllerBase
{

    [HttpPost("v1/order")]
    public async Task<GenericCommandResult> GetAllAsync(
        [FromBody] CreateOrderCommand command,
        [FromServices] OrderHandler handler)
    {
        return await handler.Handle(command);
    }


    [HttpGet("v1/order")]
    public async Task<List<Order>> GetAllOrderAsync(
        [FromServices] IOrderRepository repository,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        return await repository.GetAll(page, pageSize);
    }

    [HttpGet("v1/order/{id:guid}")]
    public async Task<GenericCommandResult> GetOrderByIdAsync(
        [FromRoute] Guid id,
        [FromServices] OrderHandler handler)
    {
        return await handler.Handle(id);
    }

    [HttpPatch("v1/order")]
    public async Task<GenericCommandResult> PatchStatusOrderAsync(
        [FromBody] PatchStatusOrderCommand command,
        [FromServices] OrderHandler handler)
    {
        return await handler.Handle(command);
    }

    [HttpDelete("v1/order/{id}")]
    public async Task<GenericCommandResult> DeleteOrderAsync(
        [FromRoute] DeleteOrderCommand command,
        [FromServices] OrderHandler handler)
    {
        return await handler.Handle(command);
    }
}