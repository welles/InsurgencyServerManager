using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace InsurgencyServerManager.Data;

public class DataManager
{
    private const string DataDirectoryName = "InsurgencyServerManager";

    private static string DataDirectoryPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DataManager.DataDirectoryName);

    private const string ModEntriesFileName = "ModEntries.json";

    private static string ModEntriesFilePath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DataManager.DataDirectoryName, DataManager.ModEntriesFileName);

    public DataManager()
    {
        Directory.CreateDirectory(DataManager.DataDirectoryPath);

        if (!File.Exists(DataManager.ModEntriesFilePath))
        {
            File.Create(DataManager.ModEntriesFilePath);
        }
    }

    public IEnumerable<ModEntry> GetModEntries()
    {
        var text = File.ReadAllText(DataManager.ModEntriesFilePath);

        return JsonConvert.DeserializeObject<ModEntry[]>(text) ?? ArraySegment<ModEntry>.Empty;
    }

    public void AddModEntry(ModEntry mod)
    {
        var mods = this.GetModEntries().ToList();

        mods.Add(mod);

        var text = JsonConvert.SerializeObject(mods, Formatting.Indented);

        File.WriteAllText(DataManager.ModEntriesFilePath, text);
    }
}
