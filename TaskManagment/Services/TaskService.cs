
using TaskManagment.Exceptions;
using TaskManagment.Models;
// 3.2 -deki Title-a görə Siyahıdan task-i tapan metod-da eger hec bir task tapilmasa NotFoundException qaytarsın
// 3.3 string-i enum-a cevirmeyi goster
// // 3.4 -də göndərilən Id-də element tapılmasa NotFoundException
//     internal class TaskService
    public class TaskService : ITaskService
    {
        public static List<MyTask> Tasks = new();
        public void AddTask(MyTask Task)
        {
            foreach(var task in Tasks)
        {
            if(Task.Title == task.Title)
            {
                throw new ConflictException("Task with this title already exists");
            }
            Tasks.Add(Task);
        }
        }
        public MyTask FindByTitle(string title)
        {
            foreach(var task in Tasks)
            {
            if(task.Title == title)
            {
                return task;
            }
            throw new NotFoundException("No tasks with this title");
            }
        }
        public string FindByStatus(TaskStatus status)
        {
            return " ";
        }
        public void DeleteById(int id)
        {
            
        }
    }

