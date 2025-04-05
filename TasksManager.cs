using System.Text.Json;

namespace TaskTracker;
public class TasksManager
{
    private static string filePath = @"C:\Users\Gabriel\RiderProjects\TaskTracker\Tasks.json";
    private static TasksObjects tasks;
    
    public static TasksObjects LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<TasksObjects>(json);
        }
        return tasks;
    }

    public static void SaveTasks(TasksObjects tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}