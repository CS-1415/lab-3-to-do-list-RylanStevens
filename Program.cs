public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(int id, string title, string description)
    {
        Id = id;
         Title = title;
         Description = description;
         IsCompleted = false;
    }

    public void DisplayTask()
    {
        string status = IsCompleted ? "[X]" : "[  ]";
        Console.WriteLine($"{status} {Id} {Title}");
    }
    public void DisplayDescription()
    {
        Console.WriteLine($"Task {Id}: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
    }
    public void MarkAsCompleted()
    {
        IsCompleted = !IsCompleted;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Task> taskList = new List<Task>();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("ID   Task");
            Console.Write("------------------------------------");


            foreach (var task in taskList)
            {
                task.DisplayTask();
            }
            Console.WriteLine();
            Console.WriteLine("Press '+' to add a task. Press 'x' to toggle whether or not the task is complete. Press 'i' to view a task's information.");
            string input = Console.ReadLine();

            switch (input)
            {
                case "i":
                    Console.Write("Enter task Id for details: ");
                    if (int.TryParse(Console.ReadLine(), out int infoId))
                    {
                        var task = taskList.Find(t => t.Id == infoId);
                        if (task != null)
                        {
                            Console.Clear();
                            task.DisplayDescription();
                            Console.WriteLine("Press a key to return to taks list");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Invalid task id");
                        }
                    }
                    break;
                
                case "+":
                    Console.Write("Enter Task Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    int newTaskId = taskList.Count + 1;
                    taskList.Add(new Task(newTaskId, title, description));
                    break;

                case "x":
                    Console.Write("Enter task ID to toggle completion: ");
                    if (int.TryParse(Console.ReadLine(), out int toggleId))
                    {
                       var task = taskList.Find(t => t.Id == toggleId);
                       if (task != null)
                    {
                        task.MarkAsCompleted();
                    }
                    else
                    {
                        Console.WriteLine("Invalid task id.");
                    } 
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }
    }
}