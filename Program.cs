namespace TaskTracker;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi");
        TasksObjects a = TasksManager.LoadTasks();
        Console.WriteLine(a.Task1);
        a.Task1 = Console.ReadLine();
        TasksManager.SaveTasks(a);
    }
}
