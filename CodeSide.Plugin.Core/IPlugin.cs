using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSide.Plugin.Core
{
    public interface IPlugin
    {
        /// <summary>
        /// The plugin name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The plugin version
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Initialize the plugin
        /// </summary>
        /// <returns>Has initialized <see cref="true"/>; otherwise <see cref="false"/></returns>
        Task<bool> Initialize();
    }
}
