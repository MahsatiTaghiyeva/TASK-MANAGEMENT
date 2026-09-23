using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyTask
{
    private static int Count = 0;
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Created { get; }
    public DateTime DeadLine { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }

    public MyTask(string title, string description, DateTime deadLine, TaskStatus taskStatus, TaskPriority taskPriority)
    {
        Count++;
        Id = Count;
        Created = DateTime.Now;
        Title = title;
        Description = description;
        DeadLine = deadLine;
        TaskStatus = taskStatus;
        TaskPriority = taskPriority;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Description: {Description}, Created: {Created}, Deadline: {DeadLine}, Task Status: {TaskStatus}, Task Priority: {TaskPriority} ";
    }
}
