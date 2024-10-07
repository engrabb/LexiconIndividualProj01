using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconIndividualProj01
{
    public class TaskHandler
    {
        Tasks task1 = new Tasks();
        private List<Tasks> tasksList;

        public TaskHandler()
        {
            tasksList = new List<Tasks>();
        }
        
        public void AddTask(Tasks tasks)
        {
            tasksList.Add(tasks);
        }
        public void RemoveTask(Tasks tasks)
        {
            tasksList.Remove(tasks);
        }
        public void EditTask(Tasks tasks, string newTitle, DateTime newDueDate, string newProject) 
        {
            tasks.Title = newTitle;
            tasks.DueDate = newDueDate;
            tasks.Project = newProject;

        }
        public void MarkAsComplete(Tasks tasks) 
        {
            task1.TaskDone();
        }
        public Tasks GetTaskByTitle(string title)
        {
            return tasksList.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowTasks()
        {
            LoadTasks(tasksList);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Title",-20}{"Date",-20}{"Project",-20}{"Status",-20}");
            tasksList
                .OrderBy(tasksList => tasksList.Title)
                .Select(tasksList => $"{tasksList.Title,-20}{tasksList.DueDate.ToString("yyyy/MM/dd"),-20}{tasksList.Project,-20}{tasksList.ToString(),-20}")
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine(new string('-', 50));
        }
        public void SortByDate()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Date",-20}{"Title",-20}{"Project",-20}{"Status",-20}");
            tasksList
                .OrderBy(t => t.DueDate).ToList()
                .Select(tasksList => $"{tasksList.DueDate.ToString("yyyy/MM/dd"),-20}{tasksList.Title,-20}{tasksList.Project,-20}{tasksList.ToString(),-20}")
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

        }
        public void SortByProject() 
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Project",-20}{"Date",-20}{"Title",-20}{"Status",-20}");
            tasksList
                .OrderBy(t => t.DueDate).ToList()
                .Select(tasksList => $"{tasksList.Project,-20}{tasksList.DueDate.ToString("yyyy/MM/dd"),-20}{tasksList.Title,-20}{tasksList.ToString(),-20}")
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
        
        public List<Tasks> GetAllTasks()
        {
            return tasksList;
        }
        public void LoadTasks(List<Tasks> loadedTasks)
        {
            tasksList = loadedTasks;
        }
        
    }
}
