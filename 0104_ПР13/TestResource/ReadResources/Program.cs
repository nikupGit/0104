using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ReadResources
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ResourceReader reader = new ResourceReader("CarResources.resources"))
            {
                IDictionaryEnumerator enumerator = reader.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string key = (string)enumerator.Key;
                    object value = enumerator.Value;
                    if (value is string)
                    {
                        Console.WriteLine("{0}: {1}", key, value);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
