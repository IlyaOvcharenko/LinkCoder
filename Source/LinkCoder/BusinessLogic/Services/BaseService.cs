using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.LogProviders;

namespace BusinessLogic.Services
{
    public abstract class BaseService
    {
        protected LogProvider Logger = new LogProvider();
    }
}
