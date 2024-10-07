using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconIndividualProj01
{
    public class Tasks
    {

        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public string Project {  get; set; }

        public Tasks(string title, DateTime dueDate, string project)
        {
            Title = title;
            DueDate = dueDate;
            Completed = false;
            Project = project;
        }
        public Tasks() { }

        public void TaskDone()
        {
            Completed = true;

        }

        public override string ToString()
        {
            string status = Completed ? "Done" : "Pending";
            return $"{status}";
        }
    }
}
