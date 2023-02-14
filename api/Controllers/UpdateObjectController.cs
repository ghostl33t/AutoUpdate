using api.Repositories.FilesForUpdate.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("object-check")]
public class UpdateObjectController : Controller
{
    private readonly IUpdateObjectCreate _updateObjectCreate;
    private readonly IUpdateObjectUpdate _updateObjectUpdate;
    public UpdateObjectController(IUpdateObjectCreate updateObjectCreate,IUpdateObjectUpdate updateObjectUpdate)
    {
        _updateObjectCreate = updateObjectCreate;
        _updateObjectUpdate = updateObjectUpdate;   
    }

    [HttpPost]
    public async Task<IActionResult> CreateListOfDLLsAsync()
    {
        await _updateObjectCreate.CreateListOfDLLsAsync();
        return Ok("Objects added succesfuly!");
    }
    [HttpPatch]
    public async Task<IActionResult> CreateListOfDLLsAsync(string objectName)
    {
        await _updateObjectUpdate.UpdateObjectAsync(objectName);
        return Ok("Objects added to update succesfuly!");
    }
}
