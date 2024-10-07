// See https://aka.ms/new-console-template for more information
using LexiconIndividualProj01;

Console.WriteLine("Hello, World!");
TaskHandler taskHandler = new TaskHandler();
UserMenu user = new UserMenu(taskHandler);
var savedTasks = FileHandler.LoadFromFile();
taskHandler.LoadTasks(savedTasks);
user.Run();