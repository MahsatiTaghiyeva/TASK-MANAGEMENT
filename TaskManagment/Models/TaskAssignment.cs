public class TaskAssignment
{
    private static int Count = 0;
    public int Id {get; set;}
    public int TaskId {get; set;} 
    public int UserId {get; set;}
    public DateTime AssignedDate {get;}
    public TaskAssignment(int taskId, int userId, DateTime assignedDate)
    {
        Count++;
        Id = Count;
        TaskId = taskId;
        UserId = userId;
        AssignedDate = DateTime.Now;
    }
}
