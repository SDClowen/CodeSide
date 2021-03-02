using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSide.Plugin.Core;

namespace CodeSide.FileHistory.Plugin
{
    public class FileHistoryPlugin : IPlugin
    {
        public string Name => "File History Plugin";
        public Version Version => new Version(1, 0, 0, 1);

        public Task<bool> Initialize()
        {
            return Task.FromResult<bool>(true);
        }
    }
}
