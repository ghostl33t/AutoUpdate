namespace serverService.Data;
public class SetupUpdate
{
    public long Id { get; set; } = 0;
    public int RepeatUpdateMinutes { get; set; }
    public int ClearDLLTableMinutes { get; set; }
    public string DLLServerPath { get; set; } = string.Empty;
    public string OtherServerPath { get; set; } = string.Empty;

}
