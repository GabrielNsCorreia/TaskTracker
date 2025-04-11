using System.Text.Json;

namespace TaskTracker;
public class TasksManager
{
    private static string filePath = @"C:\Users\Gabriel\RiderProjects\TaskTracker\Tasks.json";
    private static List<TasksObjects> tasks = new List<TasksObjects>();
    
    public static List<TasksObjects> LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TasksObjects>>(json) ?? new List<TasksObjects>();
        }
        return tasks;
    }

    public static void SaveTasks(List<TasksObjects> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}