using System;
using System.Collections.Generic;
using System.Linq;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}

//================Inheritance===============================
class Assignment
{
    private int deadline = 0; //encapsulation

    public int Deadline
    {
        get { return deadline; }
        set{
            if (value >= 0) //Validation
            deadline = value;
            else
            Console.WriteLine("Deadline here.");
            }
        }
    public void go()
    {
        Console.WriteLine("This is an inheritance program");
    }
}

class Dotnet : Assignment
{
    public int marks = 4;
}

class Java : Assignment
{
    public int marks = 2;
}

//====================================================

class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();

    static void AddTask()
    {
        TaskItem task = new TaskItem();

        Console.Write("Enter ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }
        task.Id = id;

        Console.Write("Enter Description: ");
        task.Description = Console.ReadLine();

        task.Status = "Pending";

        tasks.Add(task);

        Console.WriteLine("Task added successfully.");
    }

    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        foreach (TaskItem task in tasks)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("ID: " + task.Id);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Status: " + task.Status);
        }
    }

    static void CompleteTask()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        TaskItem task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            task.Status = "Completed";
            Console.WriteLine("Task completed.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Enter ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        TaskItem task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    static void SearchTask()
    {
        Console.Write("Enter search text: ");
        string search = Console.ReadLine();

        var results = tasks.Where(t =>
            (t.Description != null &&
 t.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
||
(t.Status != null &&
 t.Status.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0));

        if (!results.Any())
        {
            Console.WriteLine("Task not found.");
            return;
        }

        Console.WriteLine("\nMatching Tasks:");

        foreach (var task in results)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Status: {task.Status}");
        }
    }

    static void Main()
    {


        //==============inheritance=================
        Dotnet dotnet = new Dotnet();
        Java java = new Java();

        Console.WriteLine(dotnet.Deadline); //encapsulation
        java.go();

        //==========================================

        while (true)
        {
            Console.WriteLine("\n===== TASK MANAGER =====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Search Task");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;

                case 2:
                    ListTasks();
                    break;

                case 3:
                    CompleteTask();
                    break;

                case 4:
                    DeleteTask();
                    break;

                case 5:
                    SearchTask();
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}