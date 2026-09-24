using TaskPriority = TaskManagment.Enums.TaskPriority;
using TaskStatus = TaskManagment.Enums.TaskStatus;
using TaskManagment.Exceptions;
using TaskManagment.Interfaces;
using TaskManagment.Models;

namespace TaskManagment.Services
{
    public class TaskService : ITaskService
    {
        public static MyTask[] Tasks = new MyTask[0];

        private static TaskAssignment[] Assignments = new TaskAssignment[0];

        private readonly IUserService _userService;

        public TaskService(IUserService userService)
        {
            _userService = userService;
        }

        public void AddTask(MyTask task)
        {
            foreach (var existingTask in Tasks)
            {
                if (existingTask.Title == task.Title)
                {
                    throw new ConflictException(
                        "A task with this title already exists.");
                }
            }

            Array.Resize(ref Tasks, Tasks.Length + 1);
            Tasks[^1] = task;
        }

        public MyTask FindByTitle(string title)
        {
            foreach (var task in Tasks)
            {
                if (task.Title == title)
                {
                    return task;
                }
            }

            throw new NotFoundException(
                $"No task with {title} title.");
        }

        public List<MyTask> FindByStatus(string status)
        {
            if (!Enum.TryParse<TaskStatus>(
                status,
                true,
                out TaskStatus taskStatus))
            {
                throw new NotFoundException(
                    $"Status '{status}' not found.");
            }

            List<MyTask> taskList = new();

            foreach (var task in Tasks)
            {
                if (task.TaskStatus == taskStatus)
                {
                    taskList.Add(task);
                }
            }

            if (taskList.Count == 0)
            {
                throw new NotFoundException(
                    $"No tasks found with status '{status}'.");
            }

            return taskList;
        }

        public void DeleteById(int id)
        {
            int index = -1;

            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new NotFoundException(
                    $"Task with ID {id} not found.");
            }

            for (int i = index; i < Tasks.Length - 1; i++)
            {
                Tasks[i] = Tasks[i + 1];
            }

            Array.Resize(ref Tasks, Tasks.Length - 1);
        }

        public List<MyTask> FindByPriority(string priority)
        {
            if (!Enum.TryParse<TaskPriority>(
                priority,
                true,
                out TaskPriority taskPriority))
            {
                throw new NotFoundException(
                    $"Priority '{priority}' not found.");
            }

            List<MyTask> tasks = new();

            foreach (var task in Tasks)
            {
                if (task.TaskPriority == taskPriority)
                {
                    tasks.Add(task);
                }
            }

            if (tasks.Count == 0)
            {
                throw new NotFoundException(
                    $"No tasks found with priority '{priority}'.");
            }

            return tasks;
        }

        public void ChangePriority(int id, TaskPriority priority)
        {
            foreach (var task in Tasks)
            {
                if (task.Id == id)
                {
                    task.TaskPriority = priority;
                    return;
                }
            }

            throw new NotFoundException(
                $"Task with ID {id} not found.");
        }

        public void AssignTaskToUser(int taskId, int userId)
        {
            bool taskFound = false;

            foreach (var task in Tasks)
            {
                if (task.Id == taskId)
                {
                    taskFound = true;
                    break;
                }
            }

            if (!taskFound)
            {
                throw new NotFoundException(
                    $"Task with ID {taskId} not found.");
            }

            TaskAssignment assignment =
                new TaskAssignment(taskId, userId, DateTime.Now);

            Array.Resize(
                ref Assignments,
                Assignments.Length + 1);

            Assignments[^1] = assignment;
        }

        public List<MyTask> GetTasksByUser(int userId)
        {
            List<MyTask> tasks = new();

            foreach (var assignment in Assignments)
            {
                if (assignment.UserId == userId)
                {
                    foreach (var task in Tasks)
                    {
                        if (task.Id == assignment.TaskId)
                        {
                            tasks.Add(task);
                        }
                    }
                }
            }

            if (tasks.Count == 0)
            {
                throw new NotFoundException(
                    $"No tasks assigned to user with ID {userId}.");
            }

            return tasks;
        }
        public List<MyTask> GetAll()
{
    List<MyTask> tasks = new();

    foreach (var task in Tasks)
    {
        tasks.Add(task);
    }

    return tasks;
}
    }
    
}