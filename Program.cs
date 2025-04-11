using System.ComponentModel;

namespace TaskTracker;
class Program
{
    static void Main()
    {
        List<TasksObjects> tasks = TasksManager.LoadTasks();
        
        while (true)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("1 - Create \n2 - Read \n3 - Update \n4 - Delete \n5 - Exit");
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
                case "3":
                    Update(tasks);
                    break;
                case "4":
                    Delete(tasks);
                    break;
                case "5":
                    Console.WriteLine("Saving and exiting");
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
        string newId = $"TASK-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..8]}";
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

    static void Update(List<TasksObjects> tasks)
    {
        Console.Write("Write the id of the task to update: ");
        string idUpdate = Console.ReadLine();
        int index = tasks.FindIndex(x => x.id == idUpdate);
        if (index == -1)
        {
            Console.WriteLine("Task not found");
            return;
        }
        Console.Write("Write the new subject: ");
        string newSubject = Console.ReadLine();
        tasks[index].subject = newSubject;
        Console.Write("Write the new description: ");
        string newDescription = Console.ReadLine();
        tasks[index].description = newDescription;
        Console.Write("Write the new status: ");
        string newStatus = Console.ReadLine();
        tasks[index].status = newStatus;
        Console.WriteLine("Tasks updated!");
    }

    static void Delete(List<TasksObjects> tasks)
    {
        Console.Write("Write the id of the task to delete: ");
        string idDelete = Console.ReadLine();
        int index = tasks.FindIndex(x => x.id == idDelete);
        if (index == -1)
        {
            Console.WriteLine("Task not found!");
            return;
        }
        tasks.RemoveAt(index);
        Console.WriteLine("Tasks deleted!");
    }
}
