using TaskManagment.Enums;
using TaskManagment.Models;

namespace TaskManagment.Interfaces
{
    public interface ITaskService
    {
        void AddTask(MyTask task);

        MyTask FindByTitle(string title);

        List<MyTask> FindByStatus(string status);

        void DeleteById(int id);

        List<MyTask> FindByPriority(string priority);

        void ChangePriority(int id, TaskPriority priority);

        void AssignTaskToUser(int taskId, int userId);

        List<MyTask> GetTasksByUser(int userId);
    }
}