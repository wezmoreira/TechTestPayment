using Microsoft.AspNetCore.Mvc;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.SellerCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers;
using Pottencial.Domain.Repositories;

namespace Pottencial.Api.Controllers;

[ApiController]
public class SellerController : ControllerBase
{
    [HttpPost("v1/seller")]
    public async Task<GenericCommandResult> CreateSellerAsync(
        [FromBody] CreateSellerCommand command,
        [FromServices] SellerHandler handler)
    {
        return await handler.Handle(command);
    }
    
    [HttpGet("v1/seller")]
    public async Task<List<Seller>> GetAllSellerAsync(
        [FromServices] ISellerRepository repository,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        return await repository.GetAll(page, pageSize);
    }

    [HttpGet("v1/seller/{id:guid}")]
    public async Task<GenericCommandResult> GetByIdSellerAsync(
        [FromRoute] Guid id,
        [FromServices] SellerHandler handler)
    {
        return await handler.Handle(id);
    }

    [HttpPut("v1/seller/")]
    public async Task<GenericCommandResult> UpdateSellerAsync(
        [FromBody] UpdateSellerCommand command,
        [FromServices] SellerHandler handler)
    {
        return await handler.Handle(command);
    }

    [HttpDelete("v1/seller/{id}")]
    public async Task<GenericCommandResult> DeleteSellerAsync(
        [FromRoute] DeleteSellerCommand command,
        [FromServices] SellerHandler handler)
    {
        return await handler.Handle(command);
    }
}