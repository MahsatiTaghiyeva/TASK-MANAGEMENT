
public interface ITaskService
{
    public void AddTask(MyTask Task);
    public MyTask FindByTitle(string title);
    public List<MyTask> FindByStatus(string status);
    public void DeleteById(int id);
    public List<MyTask> FindByPriority(string priority);
    public void ChangePriority(int id, TaskPriority priority);
    public void AssignTaskToUser(int TaskId, int UserId);
    List<MyTask> GetTasksByUser(int userId);
}

