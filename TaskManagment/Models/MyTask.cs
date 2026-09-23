using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    internal class MyTask
    {
        public int Id { get; set; }
        private static int Count = 0;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime DeadLine { get; set; }
        public TaskStatus TaskStatus { get; set; }

        public MyTask()
        {
            Count++;
            Id = Count;
            Created = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Description: {Description}, Created: {Created}, Deadline: {DeadLine}, TaskStatus: {TaskStatus}";
        }
    }
}
