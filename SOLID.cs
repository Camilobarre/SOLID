using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var taskManager = new TaskManager();
        var taskUI = new TaskUI(taskManager);

        taskUI.Run();
    }
}

public class TaskManager
{
    private List<string> tasks = new List<string>();

    // Añadir una tarea
    public void AddTask(string task)
    {
        tasks.Add(task);
    }

    // Actualizar una tarea
    public void UpdateTask(int index, string updatedTask)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index] = updatedTask;
        }
    }

    // Eliminar una tarea
    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }

    // Listar todas las tareas
    public List<string> GetAllTasks()
    {
        return tasks;
    }
}

public class TaskUI
{
    private TaskManager taskManager;

    public TaskUI(TaskManager taskManager)
    {
        this.taskManager = taskManager;
    }

    public void Run()
    {
        bool flag = true;

        while (flag)
        {
            ShowMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    flag = false;
                    break;
                case "1":
                    ShowTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    UpdateTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    // Mostrar el menú de opciones
    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Enter the option:");
        Console.WriteLine("1 => List all tasks");
        Console.WriteLine("2 => Add a new task");
        Console.WriteLine("3 => Update a task");
        Console.WriteLine("4 => Delete a task");
        Console.WriteLine("0 => Exit");
    }

    // Mostrar todas las tareas
    private void ShowTasks()
    {
        Console.Clear();
        var tasks = taskManager.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            Console.WriteLine("List of tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1} => {tasks[i]}");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    // Agregar una tarea
    private void AddTask()
    {
        Console.Clear();
        Console.Write("Write the task => ");
        string newTask = Console.ReadLine();
        taskManager.AddTask(newTask);
    }

    // Actualizar una tarea
    private void UpdateTask()
    {
        Console.Clear();
        Console.Write("Write the index of the task to update => ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1; // Adjust index to 0-based
        Console.Write("Write the updated task => ");
        string updatedTask = Console.ReadLine();
        taskManager.UpdateTask(index, updatedTask);
    }

    // Eliminar una tarea
    private void DeleteTask()
    {
        Console.Clear();
        Console.Write("Write the index of the task to delete => ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1; // Adjust index to 0-based
        taskManager.RemoveTask(index);
    }
}