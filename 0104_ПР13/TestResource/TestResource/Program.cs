using System;
using System.Resources;


namespace TestResource
{
    public class Program
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("GreetingResource", typeof(Program).Assembly);
            Console.WriteLine(rm.GetString("prompt"));
            string name = Console.ReadLine();
            Console.WriteLine(rm.GetString("greeting"), name);
            Console.ReadKey();
        }
    }
}