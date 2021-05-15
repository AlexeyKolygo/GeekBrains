using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)

        {
            while (true)
            {
                Console.WriteLine(@"
 ____________________________________________________________________________________________________
Contents
1 - Задание 1 Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
2 - Задание 2 Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
3 - Задание 3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
4* - Задание 4. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл
5* - Задание 5. Список задач (ToDo-list)
ESC - Завершить
Please input the task number:
            _____________________________________________________________________________________________________
                            ");

                ConsoleKeyInfo ch;
                ch = Console.ReadKey();
                Console.WriteLine();
                switch (ch.Key)
                {

                    case ConsoleKey.D1://Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        var StringToSave = Console.ReadLine();
                        SaveTextToFile(StringToSave);

                        break;
                    case ConsoleKey.D2://Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        var TimeString = Console.ReadLine();
                        SaveTextWithTime(TimeString);

                        break;
                    case ConsoleKey.D3: //Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        string inputstring = Console.ReadLine();
                        int n;
                        Int32.TryParse(inputstring, out n);

                        SavetoBinary(n);

                        break;
                    case ConsoleKey.D4: //Сохранить дерево каталогов и файлов по заданному пути в текстовый файл
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        string directories = Directory.GetCurrentDirectory();
                        Console.WriteLine(directories);
                        GetFiles(directories);

                        break;
                    case ConsoleKey.D5://Список задач (ToDo-list)
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        Console.WriteLine("Your Tasks are");
                        Task task = new Task();
                        task.ReadAllTasksFromFile();
                        ;
                        Console.WriteLine("Please input Task title to set a new Task:");
                        var title = Console.ReadLine();
                        if (title.Length != 0)
                        {

                            var newtask = new Task(task.GetLastId(), title, false);
                            newtask.SetTaskToFile();
                        }

                        Console.WriteLine("Please input Task number to mark the task done:");
                        var marker = Console.ReadLine();
                        int i;
                        int.TryParse(marker, out i);
                        task.MarkTaskDone(i);
                        Console.Clear();
                        Console.WriteLine("Your Tasks are");
                        task.ReadAllTasksFromFile();

                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("TThank you!");
                        return;
                }
            }

            static void SaveTextToFile(string x)
            {
                string filename = "Console.txt";
                string SaveDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string FileSave = Path.Combine(SaveDir, filename);
                File.AppendAllText(FileSave, x + "\n");
                Console.WriteLine($"Файл сохранен в директории:{FileSave}");
            }

            static void SaveTextWithTime(string x)
            {
                string filename = "startup.txt";
                string SaveDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string FileSave = Path.Combine(SaveDir, filename);
                File.AppendAllText(FileSave, x + " " + DateTime.Now.ToString("t") + "\n");
                Console.WriteLine($"Файл сохранен в директории:{FileSave}");
            }

            static void SavetoBinary(int x)
            {
                byte[] outbyte = Encoding.ASCII.GetBytes(x.ToString());
                string filename = "bytes.bin";
                string SaveDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string FileSave = Path.Combine(SaveDir, filename);
                File.WriteAllBytes(FileSave, outbyte);


            }

            static void GetFiles(string directory)
            {
                string filename = "folder_tree.txt";
                string SaveDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string FileSave = Path.Combine(SaveDir, filename);

                Console.WriteLine($"Вы находитесь тут: {directory}");
                string[] directories = Directory.GetDirectories(Environment.CurrentDirectory);

                var lines = new StringBuilder();

                lines.AppendLine("Список директорий в папке:");
                lines.AppendJoin(Environment.NewLine, directories.DefaultIfEmpty("Нет папок"));
                lines.AppendLine(Environment.NewLine);
                File.AppendAllText(FileSave, lines.ToString());

                foreach (string str in directories)
                {
                    File.AppendAllText(FileSave, str + " " + "\n");
                }
  
                string[] files = Directory.GetFiles(directory);
                var lines2 = new StringBuilder();

                lines2.AppendLine("Список файлов в папке:");
                lines2.AppendJoin(Environment.NewLine, directories.DefaultIfEmpty("Нет файлов"));
                lines2.AppendLine(Environment.NewLine);
                File.AppendAllText(FileSave, lines2.ToString());
                for (int i = 0; i < files.Length; i++)
                {

                    File.AppendAllText(FileSave, files[i] + " " + "\n");
                }

                Console.WriteLine($"Файл сохранен тут:{FileSave}");
            }


        }



    }

}



