using System.ComponentModel;

namespace TaskTracker;
class Program
{
    static void Main()
    {
        List<TasksObjects> tasks = TasksManager.LoadTasks();
        
        while (true)
        {
            Console.WriteLine("1 - Create a new task \n2 - Read Tasks \n5 - Exit");
            Console.Write("Option: ");
            string option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    Create(tasks);
                    break;
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

    static void Create(List<TasksObjects> tasks)
    {
        int newId = tasks.Count;
        Console.Write("Write the task subject: ");
        string newSubject = Console.ReadLine();
        Console.Write("Write the task description: ");
        string newDescription = Console.ReadLine();
        
        tasks.Add(new TasksObjects{id = newId, subject = newSubject, description = newDescription, status = "Not-Done"});
        Console.WriteLine("Tasks created!");
    }

    static void Read(List<TasksObjects> tasks)
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Id: {task.id} \nSubject: {task.subject} \nDescription: {task.description} \nStatus: {task.status} \n");
        }
    }
}
