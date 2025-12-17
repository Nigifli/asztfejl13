using Bills.Core.Interfaces;
using Bills.Core.Models;
using Bills.Core.Req;
using System.ComponentModel.DataAnnotations;

namespace Bills.Api.Controllers;

public class ItemController(IItemService itemService) : BaseController
{
    [HttpGet]
    [Route("api/items")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await itemService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/items/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await itemService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/items/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ItemModelReq item)
    {
        var result = await itemService.CreateAsync(item);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/items/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ItemModelReq item)
    {
        var result = await itemService.UpdateAsync(item);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/items/delete")]
    public async Task<IActionResult> DeleteAsync([FromBody][Required] ItemModel item)
    {
        var result = await itemService.DeleteAsync(item);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
