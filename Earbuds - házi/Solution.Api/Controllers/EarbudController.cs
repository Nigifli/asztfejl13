namespace Solution.Api.Controllers;

public class EarbudController(IEarbudService earbudService): BaseController
{
    [HttpGet]
    [Route("api/earbud/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await earbudService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/earbud/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] [Required] string id)
    {
        var result = await earbudService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/earbud/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] string id)
    {
        var result = await earbudService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/earbud/create")]
    public async Task<IActionResult> CreateAsync([FromBody] [Required] EarbudModel model)
    {
        var result = await earbudService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/earbud/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] EarbudModel model)
    {
        var result = await earbudService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/earbud/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await earbudService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}