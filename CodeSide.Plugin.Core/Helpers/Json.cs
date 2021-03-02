using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSide.Plugin.Core.Helpers
{
    public class Json
    {
        private static readonly object _lock = new object();

        /// <summary>
        /// Read the file and auto-fill the type you want
        /// </summary>
        /// <typeparam name="T">Type to convert</typeparam>
        /// <param name="filePath">File path to read</param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath)
        {
            lock (_lock)
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }

        /// <summary>
        /// Serialize json and save the file
        /// </summary>
        /// <param name="filePath">File path to be saved</param>
        /// <param name="val">Object to be Convert</param>
        /// <param name="format">Serialize format</param>
        public static void SerializeToFile(string filePath, object val)
        {
            lock (_lock)
                File.WriteAllText(filePath, JsonConvert.SerializeObject(val, Formatting.Indented));
        }
    }
}
