using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Services
{
    internal class TaskService
    {
        public static List<MyTask> tasks;
        void AddTask(string title, string description, DateTime created, DateTime deadline)
        {
            MyTask task = new MyTask(created);
            task
        }
    }
}
