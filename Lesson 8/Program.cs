using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;



namespace Lesson_8
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var appfile = File.ReadAllText("appsettings.json");
            var jsonstring = JsonSerializer.Deserialize<Settings>(appfile);
            Console.WriteLine("This is current settings:");
            Console.WriteLine(jsonstring.HelloWord);
            Console.WriteLine(jsonstring.UserName);
            Console.WriteLine(jsonstring.Age);
            Console.WriteLine(jsonstring.Profession);
            Console.WriteLine("Enter new settings consequently");
            Console.WriteLine("Type your username and press Enter");
            var username = Console.ReadLine();
            Console.WriteLine("Now type preferred greeting line");
            var helloword = Console.ReadLine();
            Console.WriteLine("How old are you, kiddo?");
            var age = Console.ReadLine();
            Console.WriteLine("What's your profession?");
            var profession = Console.ReadLine();

            var settings = new Settings(username, helloword, age, profession);
            settings.SettingsSetter();
        }

        
    }

    public class Settings
    {
        public string UserName { get; set; }
        public string HelloWord { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }

        public Settings() { }

         public Settings(string _username,string _helloword,string _age,string _profession)
        {
            this.UserName = _username;
            this.HelloWord = _helloword;
            this.Age = _age;
            this.Profession = _profession;
        }

        public void SettingsSetter()
        {
            Settings settings = new Settings(this.UserName, this.HelloWord, this.Age, this.Profession);
            string jsonsettings = JsonSerializer.Serialize(settings);
            File.WriteAllText("appsettings.json", jsonsettings);
        }

    }
}
