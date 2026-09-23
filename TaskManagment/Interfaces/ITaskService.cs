
using TaskManagment.Models;

public interface ITaskService
    {
        public void AddTask(MyTask Task);
        public MyTask FindByTitle(string title);
        public string FindByStatus(TaskStatus status);
        public void DeleteById(int id);
    }

