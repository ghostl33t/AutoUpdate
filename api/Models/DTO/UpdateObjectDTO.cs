using api.Models.Domain;
namespace api.Models.DTO;
public class UpdateObjectDTO
{
    public string FileName { get; set; } = string.Empty;
    public FileType FileType { get; set; } = FileType.DLL;

    public AssemblyType AssemblyType { get; set; } = AssemblyType.Regsvr32;
    public UpdateFile UpdateFile { get; set; } = UpdateFile.YES;
    public string FileVersion { get; set; } = string.Empty;
}