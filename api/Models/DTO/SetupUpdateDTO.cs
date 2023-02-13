
namespace api.Models.DTO;
public class SetupUpdateDTO
{
    public int RepeatUpdateMinutes { get; set; }
    public int ClearDLLTableMinutes { get; set; }
    public string DLLServerPath { get; set; } = string.Empty;
    public string OtherServerPath { get; set; } = string.Empty;

}
