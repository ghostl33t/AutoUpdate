using api.Models.DTO;
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

    //TODO: Ovu metodu pozvati ako je ImelUpdateList = 0 u Registriju
    [HttpPost]
    public async Task<IActionResult> CreateListOfDLLsAsync()
    {
        await _updateObjectCreate.CreateListOfDLLsAsync();
        return Ok("Objects added successfuly!");
    }
    //TODO: Ovu metodu pozvati ako je razlicita verzija DLLa 
    //u bazi i u server sistemu
    [HttpPatch]
    public async Task<IActionResult> UpdateListOfDLLsAsync(UpdateObjectDTO updateObject)
    {
        await _updateObjectUpdate.UpdateObjectAsync(updateObject.FileName, updateObject.FileVersion);
        return Ok("Objects added to update successfuly!");
    }
    //TODO: Ovu metodu pozvati ako je vrijeme isteklo za update
    //tj ponisti sve dllove u bazi
    [HttpPatch]
    [Route("disable-update")]
    public async Task<IActionResult> DisableObjectUpdateAsync()
    {
        await _updateObjectUpdate.DisableObjectUpdateAsync();
        return Ok("Objects update disabled successfuly!");
    }

}
