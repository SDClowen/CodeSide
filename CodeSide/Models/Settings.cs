using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSide.Models
{
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Use ordering while tab closing. Otherwise it will ordering with last selected file.
        /// </summary>
        public bool UseOrderingWhileTabClosing { get; internal set; } = true;

        /// <summary>
        /// Show file name info on title; otherwise not show anyting
        /// </summary>
        public bool ShowFileNameInfoOnTitle { get; internal set; } = true;

        /// <summary>
        /// Show file name instead of path name on title
        /// </summary>
        public bool ShowFileNameOnTitleInsteadOfPath { get; internal set; } = true;

        /// <summary>
        /// File opened history
        /// </summary>
        public Stack<DocumentHistoryItem> History { get; set; } = new Stack<DocumentHistoryItem>();

        /// <summary>
        /// Try load program settings from settings file
        /// </summary>
        /// <param name="settings">Out generated settings structure</param>
        /// <returns>If success <seealso cref="true"/> otherwise; <seealso cref="false"/> </returns>
        internal static bool TryLoad(out Settings settings)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CodeSide");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (var stream = new FileStream(Path.Combine(folder, "settings.sd"), FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, 512))
            {
                string content;
                using (var reader = new StreamReader(stream))
                    content = reader.ReadToEnd();

                settings = JsonConvert.DeserializeObject<Settings>(content);
                if (settings == null)
                    settings = new Settings();
            }


            return true;
        }

        /// <summary>
        /// Save settings to settings file
        /// </summary>
        /// <returns>If success <seealso cref="true"/> otherwise; <seealso cref="false"/> </returns>
        internal bool Save()
        {
            var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CodeSide", "settings.sd");
            
            File.WriteAllText(file, JsonConvert.SerializeObject(this, Formatting.Indented));
            
            return true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="historyItem">The document history item</param>
        internal void AddHistory(DocumentHistoryItem historyItem)
        {
            if (History.FirstOrDefault(p =>
                 p.FilePath.Equals(historyItem.FilePath, StringComparison.OrdinalIgnoreCase)) != null)
                return;

            Globals.MainWindow.menuItemHistory.MenuItems.Add(historyItem.ToString());
            History.Push(historyItem);
        }
    }
}
