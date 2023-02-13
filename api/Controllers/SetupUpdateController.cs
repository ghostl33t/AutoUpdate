using api.Models.Domain;
using api.Models.DTO;
using api.Repositories.SetupUpdate.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("setup")]
public class SetupUpdateController : Controller
{
    private readonly ISetupUpdateCreate _setupRepositoryCreate;
    private readonly ISetupUpdateGet _setupRepositoryGet;
    public SetupUpdateController(ISetupUpdateCreate setupRepositoryCreate, ISetupUpdateGet setupRepositoryGet)
    {
        _setupRepositoryCreate = setupRepositoryCreate;
        _setupRepositoryGet = setupRepositoryGet;
    }
    [HttpGet]
    public async Task<SetupUpdateDTO> GetSetupAsync()
    {
        var setupUpdate = await _setupRepositoryGet.GetSetupAsync();
        var setupDTO = new SetupUpdateDTO();
        if (setupUpdate != null)
        {
            setupDTO.RepeatUpdateMinutes = setupUpdate.RepeatUpdateMinutes;
            setupDTO.DLLServerPath = setupUpdate.DLLServerPath;
            setupDTO.OtherServerPath = setupUpdate.OtherServerPath;
            setupDTO.ClearDLLTableMinutes = setupUpdate.ClearDLLTableMinutes;
        }
        return setupDTO;
    }
    [HttpPost]
    public async Task<long> CreateSetupAsync(SetupUpdateDTO newSetupDTO)
    {
        var newSetup = new SetupUpdate()
        {
            DLLServerPath = newSetupDTO.DLLServerPath,
            OtherServerPath = newSetupDTO.OtherServerPath,
            ClearDLLTableMinutes = newSetupDTO.ClearDLLTableMinutes,
            RepeatUpdateMinutes = newSetupDTO.RepeatUpdateMinutes
        };
        await _setupRepositoryCreate.CreateSetupAsync(newSetup);
        if(newSetup.Id != 0)
        {
            return newSetup.Id;
        }
        return 0;

    }
    [HttpPatch]
    public async Task<long> UpdateSetupAsync(SetupUpdateDTO newSetupDTO)
    {
        var newSetup = new SetupUpdate()
        {
            DLLServerPath = newSetupDTO.DLLServerPath,
            OtherServerPath = newSetupDTO.OtherServerPath,
            ClearDLLTableMinutes = newSetupDTO.ClearDLLTableMinutes,
            RepeatUpdateMinutes = newSetupDTO.RepeatUpdateMinutes
        };
        await _setupRepositoryCreate.CreateSetupAsync(newSetup);
        if (newSetup.Id != 0)
        {
            return newSetup.Id;
        }
        return 0;

    }

}
