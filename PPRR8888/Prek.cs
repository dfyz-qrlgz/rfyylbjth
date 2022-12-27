using System.Diagnostics;
using System;
using Newtonsoft.Json;

namespace PPRR8888
{
    internal class Prek
    {
        private static string Name;
        private long Time;
        private static double SpeedMin;
        private static double SpeedSec;
        public Stopwatch sw = new Stopwatch();

        public Prek(string name)
        {
            Name = name;
            Thread textWriter = new Thread(new ThreadStart(Text));
            textWriter.Start();
            sw.Start();
        }

        private void Text()
        {
            int index = 0;
            int indexProection = index;
            int yCord = 0;
            string text = "Ещё один холодный день Идти куда-то просто лень Да и никто сегодня не звонит Пейзаж в окне опять застыл Туман как в фильме Сайлент Хилл Всё тот же скучный, надоевший вид Приходи ко мне Слушать старые пластинки Divine Comedy, Питера Гэбриела и Стинга Мир сошёл с ума Надоело всё, что там снаружи Давай до утра старые пластинки слушать";
            Console.Write(text);
            char[] characters = text.ToCharArray();
            while (true)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Время: " + (60 - sw.ElapsedMilliseconds / 1000));
                if (sw.ElapsedMilliseconds == 60000)
                {
                    sw.Stop();
                    Time = 60000;
                    SpeedSec = index / (Time / 1000);
                    SpeedMin = SpeedSec / 60000;
                    break;
                }
                if (index % 120 == 0 && index != 0) 
                { 
                    yCord++; indexProection = 0; 
                }
                if (index == text.Length)
                {
                    sw.Stop();
                    Time = sw.ElapsedMilliseconds;
                    SpeedSec = index / (double)(sw.ElapsedMilliseconds / 10000);
                    SpeedMin = index * ((double)sw.ElapsedMilliseconds / 60000.0);
                    break;
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == text[index])
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.ForegroundColor = ConsoleColor.Green;
                    characters[index] = key.KeyChar;
                    Console.Write(key.KeyChar);
                    Console.ResetColor();
                    index++;
                    indexProection++;
                }
                else if (key.KeyChar != text[index])
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(key.KeyChar);
                    Console.ResetColor();
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.Write(text[index]);
                }
            }
            Prek.FileSerialize();
        }
        public static void FileSerialize()
        {
            string jsonRead = "";
            if (File.Exists("C:\\Новая папка\\file3.json"))
            {
                jsonRead = File.ReadAllText("C:\\Новая папка\\file3.json");
            }
            List<TimeS> timen = JsonConvert.DeserializeObject<List<TimeS>>(jsonRead) ?? new List<TimeS>();

            timen.Add(new TimeS(Name, SpeedMin, SpeedSec));

            string json = JsonConvert.SerializeObject(timen);
            File.WriteAllText("C:\\Новая папка\\file3.json", json);

            Console.Clear();
            Console.WriteLine("Хотите ли продолжить? (y/n)");
            string answ = Console.ReadLine();
            if (answ == "y")
            {
                Console.Clear();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Clear();
                Prek newPrek = new Prek(name);
            }
            else if (answ == "n")
            {
                Console.Clear();
                Console.WriteLine("Вы вышли из программы");
            }
        }
    }
}
