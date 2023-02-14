using api.Models.DTO;
using api.Repositories.FilesForUpdate.Interface;
using api.Repositories.UpdateObject.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("object-check")]
public class UpdateObjectController : Controller
{
    private readonly IUpdateObjectCreate _updateObjectCreate;
    private readonly IUpdateObjectUpdate _updateObjectUpdate;
    private readonly IUpdateObjectRead _updateObjectRead;
    public UpdateObjectController(IUpdateObjectCreate updateObjectCreate, IUpdateObjectUpdate updateObjectUpdate, IUpdateObjectRead updateObjectRead)
    {
        _updateObjectCreate = updateObjectCreate;
        _updateObjectUpdate = updateObjectUpdate;
        _updateObjectRead = updateObjectRead;
    }
    //OVu metodu ce pozivat client servis tako da ce znat koje dllove treba da registruje
    [HttpGet]
    public async Task<IActionResult> GetDLLsForUpdate()
    {
        return Ok(await _updateObjectRead.GetDLLsForUpdate());
    }
    // Ovu metodu pozvati ako je ImelUpdateList = 0 u Registriju
    [HttpPost]
    public async Task<IActionResult> CreateListOfDLLsAsync()
    {
        await _updateObjectCreate.CreateListOfDLLsAsync();
        return Ok("Objects added successfuly!");
    }
    //Ovu metodu pozvati ako je razlicita verzija DLLa 
    //u bazi i u server sistemu
    [HttpPatch]
    public async Task<IActionResult> UpdateListOfDLLsAsync(UpdateObjectDTO updateObject)
    {
        await _updateObjectUpdate.UpdateObjectAsync(updateObject.FileName, updateObject.FileVersion);
        return Ok("Objects added to update successfuly!");
    }
    //Ovu metodu pozvati ako je vrijeme isteklo za update
    //tj ponisti sve dllove u bazi
    [HttpPatch]
    [Route("disable-update")]
    public async Task<IActionResult> DisableObjectUpdateAsync()
    {
        await _updateObjectUpdate.DisableObjectUpdateAsync();
        return Ok("Objects update disabled successfuly!");
    }

}
