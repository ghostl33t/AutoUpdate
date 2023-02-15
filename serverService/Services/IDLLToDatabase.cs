using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverService.Services;
public interface IDLLToDatabase
{
    public Task<bool> WriteDLLsToDatabase(Data.SetupUpdate setupUpdate);
    public Task<bool> ValidateObjectForUpdate(Data.SetupUpdate setupUpdate);
}
