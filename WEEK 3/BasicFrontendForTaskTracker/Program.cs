using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskTracker.Models;

class Program
{
    static async Task Main()
    {
        string baseUrl = "https://localhost:7131"; 

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Project");
            Console.WriteLine("2. Get Project by ID");
            Console.WriteLine("3. Add Task");
            Console.WriteLine("4. Get All Tasks");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        await AddProject(baseUrl);
                        break;
                    case 2:
                        await GetProjectById(baseUrl);
                        break;
                    case 3:
                        await AddTask(baseUrl);
                        break;
                    case 4:
                        await GetAllTasks(baseUrl);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static async Task AddProject(string baseUrl)
    {
        Project newProject = new Project { Name = "Sample Project" };
        string projectJson = JsonConvert.SerializeObject(newProject);
        StringContent projectContent = new StringContent(projectJson, Encoding.UTF8, "application/json");

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage addProjectResponse = await client.PostAsync($"{baseUrl}/api/projects/addProject", projectContent);
            string addProjectResult = await addProjectResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Add Project Result: {addProjectResult}");
        }
    }

    static async Task GetProjectById(string baseUrl)
    {
        Console.Write("Enter Project ID: ");
        if (long.TryParse(Console.ReadLine(), out long projectId))
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage getProjectResponse = await client.GetAsync($"{baseUrl}/api/projects/getProject/{projectId}");
                string getProjectResult = await getProjectResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Get Project Result: {getProjectResult}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Project ID must be a number.");
        }
    }

    static async Task AddTask(string baseUrl)
    {
        Task_ newTask = new Task_ { Name = "Sample Task", Description = "Task Description" };
        string taskJson = JsonConvert.SerializeObject(newTask);
        StringContent taskContent = new StringContent(taskJson, Encoding.UTF8, "application/json");

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage addTaskResponse = await client.PostAsync($"{baseUrl}/api/tasks/addTask", taskContent);
            string addTaskResult = await addTaskResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Add Task Result: {addTaskResult}");
        }
    }

    static async Task GetAllTasks(string baseUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage getAllTasksResponse = await client.GetAsync($"{baseUrl}/api/tasks/getAllTasks");
            string getAllTasksResult = await getAllTasksResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Get All Tasks Result: {getAllTasksResult}");
        }
    }
}