using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverService.Repository;
public interface ISetupUpdate
{
    public Task<Data.SetupUpdate> GetSetupAsync();
}
