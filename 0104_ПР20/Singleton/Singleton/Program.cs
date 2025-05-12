using System;
using System.Linq;

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            var cache = EntityCache.Instance;
            Type userType = typeof(User);

            Console.WriteLine("Демонстрация работы кэша:");
            Console.WriteLine($"Регистрация типа: {cache.RegisterType(userType)}");
            Console.WriteLine($"Тип зарегистрирован: {cache.ContainsType(userType)}");

            var user1 = new User { Id = 1, Name = "Alice" };
            Console.WriteLine($"Добавление user1: {cache.AddEntity(user1)}");

            var user2 = new User { Id = 2, Name = "Bob" };
            Console.WriteLine($"Добавление user2: {cache.AddEntity(user2)}");

            Console.WriteLine($"Существует user1: {cache.ContainsEntity(user1)}");
            Console.WriteLine($"Всего пользователей: {cache.GetEntities(userType).Count()}");

            Console.WriteLine($"Удаление user1: {cache.RemoveEntity(user1)}");
            Console.WriteLine($"Удаление типа: {cache.RemoveType(userType)}");
        }
    }
}