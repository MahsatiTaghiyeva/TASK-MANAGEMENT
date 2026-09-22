using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Interfaces
{
    internal interface ITaskService
    {
        void AddTask(string title, string description, DateTime created, DateTime deadline);
        string FindByTitle(string title);
        string FindByStatus(Enum status);
        void DeleteById(int id);
    }
}
