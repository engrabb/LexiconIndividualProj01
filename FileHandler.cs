using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LexiconIndividualProj01
{
    public class FileHandler
    {
        private static string filePath = "tasks.json";

        // Save tasks to file
        public static void SaveToFile(List<Tasks> tasks)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, json);
        }

        // Load tasks from file
        public static List<Tasks> LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Tasks>>(json);
            }
            return new List<Tasks>();
        }
    }
}
