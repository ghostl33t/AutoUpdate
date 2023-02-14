using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientService.Data;
public class UpdateObject
{
    public string FileName { get; set; } = string.Empty;
    public string FileVersion { get; set; } = string.Empty;
    public AssemblyType AssemblyType { get; set; } = AssemblyType.Regsvr32;

}
public enum AssemblyType
{
    Regsvr32 = 0,
    Regasm = 1
}