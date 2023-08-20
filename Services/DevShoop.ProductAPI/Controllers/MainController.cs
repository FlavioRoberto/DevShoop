using System.Collections;
using DevShoop.ProductAPI.Domain.UseCases;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevShoop.ProductAPI.Controllers;

public abstract class MainController : ControllerBase
{
    protected IActionResult Execute(UseCaseResult result)
    {
        if (!result.IsValid())
            return BadRequest(result.Errors);

        return Ok();
    }

    protected ActionResult<T> Execute<T>(UseCaseResult<T> result)
    {
        if (!result.IsValid())
            return BadRequest(result.Errors);

        if (result.Data is IEnumerable)
        {
            if (((IList)result.Data).Count == 0)
                return NoContent();
        }

        return Ok(result.Data);
    }

}
