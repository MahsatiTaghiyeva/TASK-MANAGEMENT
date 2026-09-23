using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Services
{
//     Task-lar üçün statik Massiv saxlayır özündə
// 3.1-deki tapsirigda Siyahıya Task əlavə etmək üçün metodda eyni başlıqlı Task artırılsa ConflictException qaytaracaq
// 3.2 -deki Title-a görə Siyahıdan task-i tapan metod-da eger hec bir task tapilmasa NotFoundException qaytarsın
// 3.3 string-i enum-a cevirmeyi goster
// // 3.4 -də göndərilən Id-də element tapılmasa NotFoundException
//     internal class TaskService
    {
        public static List<MyTask> tasks;
        void AddTask(string title, string description, DateTime created, DateTime deadline)
        {
            MyTask task = new MyTask(created);
            task
        }
    }
}
