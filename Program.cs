namespace TaskTracker;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hi");
        List<TasksObjects> a = TasksManager.LoadTasks();
        Console.WriteLine(a[0].Name);
        a[0].Name = Console.ReadLine();
        TasksManager.SaveTasks(a);
    }
}
