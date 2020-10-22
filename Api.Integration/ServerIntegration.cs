using Api.Interface;
using Api.OneSingle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration
{
    public static class ServerIntegration
    {
        public static IGenericApp Server
        {
            get { return new OneSingleApp(); }
        }
    }
}
