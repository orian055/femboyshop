using System.IO;
using System.Text.Json;

namespace Game
{
    static class SaveSystem
    {
        private const string SavePath = "save.json";

        public static void Save(SaveData data)
        {
            var options = new JsonSerializerOptions
            { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(SavePath, json);
        }

        public static SaveData Load()
        {
            if (!File.Exists(SavePath))
            return new SaveData();

            string json = File.ReadAllText(SavePath);
            SaveData? data = JsonSerializer.Deserialize<SaveData>(json);
            return data ?? new SaveData();
        }

        public static bool SaveExits() => File.Exists(SavePath);

        public static void DeleteSave()
        {
            if (File.Exists(SavePath))
            File.Delete(SavePath);
        }
    }
}