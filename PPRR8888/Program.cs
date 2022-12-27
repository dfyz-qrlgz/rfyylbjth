namespace PPRR8888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Clear();
            Prek newPrek = new Prek(name);
        }
    }
}