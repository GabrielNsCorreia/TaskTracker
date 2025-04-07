using System.ComponentModel;

namespace TaskTracker;
class Program
{
    static void Main()
    {
        List<TasksObjects> tasks = TasksManager.LoadTasks();
        
        while (true)
        {
            Console.WriteLine("2 - Read Tasks \n5 - Exit");
            Console.Write("Option: ");
            string option = Console.ReadLine();
            
            switch (option)
            {
                case "2":
                    Read(tasks);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            
            TasksManager.SaveTasks(tasks);
        }
    }

    static void Read(List<TasksObjects> tasks)
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Name: {task.Name} \nAge: {task.Age}");
        }
    }
}
