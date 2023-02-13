using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;
internal class SetupUpdate
{
    public long Id { get; set; } = 0;
    public int RepeatUpdateMinutes { get; set; }
    public int ClearDLLTableMinutes { get; set; }
    public string DLLServerPath { get; set; } = string.Empty;
    public string OtherServerPath { get; set; } = string.Empty;
}
