using TaskPriority = TaskManagment.Enums.TaskPriority;
using TaskStatus = TaskManagment.Enums.TaskStatus;
using TaskManagment.Exceptions;
using TaskManagment.Helpers;
using TaskManagment.Models;
using TaskManagment.Services;

UserService userService = new UserService();
TaskService taskService = new TaskService(userService);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("================================");
    Console.WriteLine("       TASK MANAGEMENT SYSTEM");
    Console.WriteLine("================================");
    Console.WriteLine("1.  Add User");
    Console.WriteLine("2.  Find User by Email");
    Console.WriteLine("3.  Add Task");
    Console.WriteLine("4.  Find Task by Title");
    Console.WriteLine("5.  Find Tasks by Status");
    Console.WriteLine("6.  Delete Task");
    Console.WriteLine("7.  Find Tasks by Priority");
    Console.WriteLine("8.  Change Task Priority");
    Console.WriteLine("9.  Assign Task to User");
    Console.WriteLine("10. Get Tasks by User");
    Console.WriteLine("11. Show Task Time");
    Console.WriteLine("12. Show All Tasks");
    Console.WriteLine("13. Show All Users");
    Console.WriteLine("0.  Exit");
    Console.WriteLine("================================");
    Console.Write("Choose: ");

    string choice = Console.ReadLine()!;

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter name: ");
                string name = Console.ReadLine()!;

                Console.Write("Enter email: ");
                string email = Console.ReadLine()!;

                User user = new User(name, email);

                userService.AddUser(user);

                Console.WriteLine();
                Console.WriteLine("User added successfully.");
                Console.WriteLine(user);
                break;

            case "2":
                Console.Write("Enter email: ");
                string searchEmail = Console.ReadLine()!;

                User foundUser = userService.FindByEmail(searchEmail);

                Console.WriteLine();
                Console.WriteLine(foundUser);
                break;

            case "3":
                Console.Write("Enter title: ");
                string title = Console.ReadLine()!;

                Console.Write("Enter description: ");
                string description = Console.ReadLine()!;

                Console.Write("Enter deadline (yyyy-MM-dd HH:mm): ");
                DateTime deadline = DateTime.Parse(Console.ReadLine()!);

                Console.WriteLine();
                Console.WriteLine("Choose status:");
                Console.WriteLine("1. ToDo");
                Console.WriteLine("2. InProgress");
                Console.WriteLine("3. Done");
                Console.Write("Choose: ");

                string statusInput = Console.ReadLine()!;

                TaskStatus status;

                switch (statusInput)
                {
                    case "1":
                        status = TaskStatus.ToDo;
                        break;

                    case "2":
                        status = TaskStatus.InProgress;
                        break;

                    case "3":
                        status = TaskStatus.Done;
                        break;

                    default:
                        throw new FormatException();
                }

                Console.WriteLine();
                Console.WriteLine("Choose priority:");
                Console.WriteLine("1. Low");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. High");
                Console.Write("Choose: ");

                string priorityInput = Console.ReadLine()!;

                TaskPriority priority;

                switch (priorityInput)
                {
                    case "1":
                        priority = TaskPriority.Low;
                        break;

                    case "2":
                        priority = TaskPriority.Medium;
                        break;

                    case "3":
                        priority = TaskPriority.High;
                        break;

                    default:
                        throw new FormatException();
                }

                MyTask task = new MyTask(
                    title,
                    description,
                    deadline,
                    status,
                    priority
                );

                taskService.AddTask(task);

                Console.WriteLine();
                Console.WriteLine("Task added successfully.");
                Console.WriteLine(task);
                break;

            case "4":
                Console.Write("Enter task title: ");
                string taskTitle = Console.ReadLine()!;

                MyTask foundTask = taskService.FindByTitle(taskTitle);

                Console.WriteLine();
                Console.WriteLine(foundTask);
                break;

            case "5":
                Console.WriteLine();
                Console.WriteLine("1. ToDo");
                Console.WriteLine("2. InProgress");
                Console.WriteLine("3. Done");
                Console.Write("Choose status: ");

                string statusChoice = Console.ReadLine()!;

                string statusName = statusChoice switch
                {
                    "1" => "ToDo",
                    "2" => "InProgress",
                    "3" => "Done",
                    _ => throw new FormatException()
                };

                List<MyTask> statusTasks =
                    taskService.FindByStatus(statusName);

                Console.WriteLine();

                foreach (MyTask item in statusTasks)
                {
                    Console.WriteLine(item);
                }

                break;

            case "6":
                Console.Write("Enter task ID: ");
                int deleteId = int.Parse(Console.ReadLine()!);

                taskService.DeleteById(deleteId);

                Console.WriteLine("Task deleted successfully.");
                break;

            case "7":
                Console.WriteLine();
                Console.WriteLine("1. Low");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. High");
                Console.Write("Choose priority: ");

                string priorityChoice = Console.ReadLine()!;

                string priorityName = priorityChoice switch
                {
                    "1" => "Low",
                    "2" => "Medium",
                    "3" => "High",
                    _ => throw new FormatException()
                };

                List<MyTask> priorityTasks =
                    taskService.FindByPriority(priorityName);

                Console.WriteLine();

                foreach (MyTask item in priorityTasks)
                {
                    Console.WriteLine(item);
                }

                break;

            case "8":
                Console.Write("Enter task ID: ");
                int taskId = int.Parse(Console.ReadLine()!);

                Console.WriteLine();
                Console.WriteLine("1. Low");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. High");
                Console.Write("Choose new priority: ");

                string newPriorityInput = Console.ReadLine()!;

                TaskPriority newPriority = newPriorityInput switch
                {
                    "1" => TaskPriority.Low,
                    "2" => TaskPriority.Medium,
                    "3" => TaskPriority.High,
                    _ => throw new FormatException()
                };

                taskService.ChangePriority(taskId, newPriority);

                Console.WriteLine("Priority changed successfully.");
                break;

            case "9":
                Console.Write("Enter task ID: ");
                int assignTaskId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter user ID: ");
                int userId = int.Parse(Console.ReadLine()!);

                taskService.AssignTaskToUser(
                    assignTaskId,
                    userId
                );

                Console.WriteLine("Task assigned successfully.");
                break;

            case "10":
                Console.Write("Enter user ID: ");
                int searchUserId = int.Parse(Console.ReadLine()!);

                List<MyTask> userTasks =
                    taskService.GetTasksByUser(searchUserId);

                Console.WriteLine();

                foreach (MyTask item in userTasks)
                {
                    Console.WriteLine(item);
                }

                break;

            case "11":
                Console.Write("Enter task title: ");
                string timeTaskTitle = Console.ReadLine()!;

                MyTask timeTask =
                    taskService.FindByTitle(timeTaskTitle);

                TimeSpan allocated =
                    timeTask.GetAllocatedTime();

                TimeSpan remaining =
                    timeTask.GetRemainingTime();

                Console.WriteLine();
                Console.WriteLine($"Task: {timeTask.Title}");
                Console.WriteLine($"Created: {timeTask.Created}");
                Console.WriteLine($"Deadline: {timeTask.DeadLine}");
                Console.WriteLine($"Allocated time: {allocated}");
                Console.WriteLine($"Remaining time: {remaining}");

                break;

            case "12":
                List<MyTask> allTasks = taskService.GetAll();

                Console.WriteLine();

                if (allTasks.Count == 0)
                {
                    Console.WriteLine("There are no tasks.");
                    break;
                }

                foreach (MyTask item in allTasks)
                {
                    Console.WriteLine(item);
                }

                break;

            case "13":
                List<User> allUsers = userService.GetAll();

                Console.WriteLine();

                if (allUsers.Count == 0)
                {
                    Console.WriteLine("There are no users.");
                    break;
                }

                foreach (User item in allUsers)
                {
                    Console.WriteLine(item);
                }

                break;

            case "0":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine($"Not Found: {ex.Message}");
    }
    catch (ConflictException ex)
    {
        Console.WriteLine($"Conflict: {ex.Message}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter the correct format.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}