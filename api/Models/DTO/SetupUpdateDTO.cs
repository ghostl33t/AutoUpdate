
namespace api.Models.DTO;
public class SetupUpdateDTO
{
    public long Id { get; set; } = 0;
    public int RepeatUpdateMinutes { get; set; }
    public int ClearDLLTableMinutes { get; set; }
    public string DLLServerPath { get; set; } = string.Empty;
    public string OtherServerPath { get; set; } = string.Empty;

}
