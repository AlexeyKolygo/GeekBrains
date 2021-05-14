using System;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Lesson_5
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public Task(int _id, string _title, bool _IsDone)
        {
            Id = _id;
            Title = _title;
            IsDone = _IsDone;
        }
        public Task()
        {
            Id = this.Id;
            Title = this.Title;
            IsDone = this.IsDone;
        }
        public void SetTaskToFile()
        {
            Task task = new Task(this.Id, this.Title, this.IsDone);
            var json = JsonSerializer.Serialize(task);
            File.AppendAllText("ToDo.json", json + ";");
        }
        public void MarkTaskDone(int i)
        {
            var purefile = FileReader();
            File.Delete("ToDo.json");
            foreach (var model in purefile)
            {
                Task task = JsonSerializer.Deserialize<Task>(model);
                if (i == Convert.ToInt32(task.Id)) { task.IsDone = true; }
                Task newTask = new Task(task.Id, task.Title, task.IsDone);
                newTask.SetTaskToFile();
            }
        }

        public string[] FileReader()
        {
            var file = File.ReadAllText("ToDo.json");
            var purefile = file.Split(';');
            purefile = purefile.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return purefile;
        }
        public void ReadAllTasksFromFile()
        {
            var purefile = FileReader();
            foreach (var model in purefile)
            {
                Task task = JsonSerializer.Deserialize<Task>(model);
                string x = "Not Done";
                if (task.IsDone) { x = "Done"; };
                Console.WriteLine($"{task.Id} '{task.Title}' Task Status:{x} ");

            }
        }

        public int GetLastId()
        {
            var file = File.ReadAllText("ToDo.json");
            var purefile = file.Split(';');
            purefile = purefile.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var task_list = new List<Task>();
            foreach (var model in purefile)
            {
                task_list.Add(JsonSerializer.Deserialize<Task>(model));
            }

            var b = task_list.OrderByDescending(x => x.Id)?.Select(x => x.Id)?.FirstOrDefault();
            var x = b == null ? 1 : (int)b;

            return x + 1;
        }
    }
}
