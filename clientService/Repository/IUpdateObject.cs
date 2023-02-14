using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientService.Repository;
public interface IUpdateObject
{
    public Task<List<Data.UpdateObject>> GetObjectsForUpdateAsync();
}
