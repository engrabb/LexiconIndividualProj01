using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconIndividualProj01
{
    public class UserMenu
    {
        private TaskHandler taskHandler;
        
        public UserMenu(TaskHandler taskHandler) 
        {
            this.taskHandler = taskHandler;
        }
        public UserMenu() { }
        public void Run()
        {
            bool running = true;
            Console.WriteLine("This is your todo list!");
            
            while (running)
            {
                Console.WriteLine("1. Show tasks sorted by date.");
                Console.WriteLine("2. Show tasks sorted by project.");
                Console.WriteLine("3. Add a new task");
                Console.WriteLine("4. Edit a task, mark as complete or delete");
                Console.WriteLine("5. Save and exit program");
                char choice = char.Parse(Console.ReadLine());
                switch (choice)
                {
                    case '1': taskHandler.SortByDate(); break;
                    case '2': taskHandler.SortByProject(); break;
                    case '3': AddTaskToList(); break;
                    case '4': EditTaskInList(); break;
                    case '5': SaveTaskList();
                        running = false;
                        break;
                        default: Console.WriteLine("Can't do that..");
                        break;

                }
            }
        }

        public void AddTaskToList()
        {
            Console.Write("What is the title of your task?: ");
            string title = Console.ReadLine();
            Console.Write("What is the project name?: ");
            string project = Console.ReadLine();

            DateTime dueDate;
            while (true)
            {
                Console.Write("When should it be completed? (yyyy-mm-dd): ");
                string dueDateInput = Console.ReadLine();
                if (DateTime.TryParseExact(dueDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dueDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid format. Please try again (format: yyyy-mm-dd).");
                }
            }


            Tasks newTask = new Tasks(title, dueDate, project);
            taskHandler.AddTask(newTask);
            Console.WriteLine("The task is in the list!");

        }
        public void EditTaskInList()
        {
            
            Console.Write("Which task do you want to edit? Search by title: ");
            string searchInput = Console.ReadLine();
            Tasks taskToEdit = taskHandler.GetTaskByTitle(searchInput);
            if (taskToEdit != null)
            {
                
                Console.Write("Do you want to mark as complete('C'), edit task('E') or delete a the task('D')?: ");
                char choice = char.Parse(Console.ReadLine().ToLower());
                switch (choice)
                {
                    case 'c': taskToEdit.Completed = true; break;
                    case 'e':
                        Console.WriteLine("New title name?: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("New project name?: ");
                        string project = Console.ReadLine();

                        DateTime dueDate;
                        while (true)
                        {
                            Console.Write("New deadline for the project(yyyy-mm-dd): ");
                            string dueDateInput = Console.ReadLine();
                            if (DateTime.TryParseExact(dueDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dueDate))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid format. Please try again (format: yyyy-mm-dd).");
                            }
                        }
                        taskHandler.EditTask(taskToEdit, newTitle, dueDate, project);
                        Console.WriteLine("The task is updated!");
                        break;
                    case 'd': taskHandler.RemoveTask(taskToEdit);
                        Console.WriteLine("Task deleted!");
                        break;
                    default: Console.WriteLine("Try again");
                        break;
                }
            }
        }
        private void SaveTaskList()
        {
            FileHandler.SaveToFile(taskHandler.GetAllTasks());
        }
    }
}
