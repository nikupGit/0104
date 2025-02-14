// Spirit.cs
using System.Linq;
using System;

// Monster.cs
using System.Reflection;


namespace SpiritLibrary
{
    public abstract class Spirit
    {
        public abstract void Passport();
    }
}


namespace SpiritLibrary
{
    public class Monster : Spirit
    {
        private string name;
        private int health, ammo;

        public Monster()
        {
            Health = 100;
            Ammo = 100;
            Name = "Noname";
        }

        public Monster(string name) : this()
        {
            Name = name;
        }

        public Monster(int health, int ammo, string name)
        {
            Health = health;
            Ammo = ammo;
            Name = name;
        }

        public int Health
        {
            get => health;
            set => health = value > 0 ? value : 0;
        }

        public int Ammo
        {
            get => ammo;
            set => ammo = value > 0 ? value : 0;
        }

        [AllowedMonsterTypes(MonsterType.Demon, MonsterType.Orc)]
        public string Name
        {
            get => name;
            private set
            {
                ValidateName(value);
                name = value;
            }
        }

        private void ValidateName(string name)
        {
            var attribute = (AllowedMonsterTypesAttribute)Attribute.GetCustomAttribute(
                typeof(Monster).GetProperty("Name"), typeof(AllowedMonsterTypesAttribute));

            var parts = name.Split('_');
            if (parts.Length < 2 || !Enum.TryParse(parts.Last(), out MonsterType type))
                throw new ArgumentException("Invalid name format.");

            if (!attribute.AllowedTypes.Contains(type))
                throw new ArgumentException($"Invalid monster type: {type}.");
        }

        public override void Passport()
        {
            Console.WriteLine($"Monster {Name}\tHealth = {Health}\tAmmo = {Ammo}");
        }
    }
}

// Daemon.cs
namespace SpiritLibrary
{
    public class Daemon : Monster
    {
        private int brain;

        public Daemon() : base() { }
        public Daemon(string name, int brain) : base(name) => Brain = brain;
        public Daemon(int health, int ammo, string name, int brain) : base(health, ammo, name) => Brain = brain;

        [MinBrain(3)]
        public int Brain
        {
            get => brain;
            set => brain = value;
        }

        public override void Passport()
        {
            Console.WriteLine($"Daemon {Name}\tHealth = {Health}\tAmmo = {Ammo}\tBrain = {Brain}");
        }

        public void Think()
        {
            Console.Write($"{Name} is");
            for (int i = 0; i < brain; i++) Console.Write(" thinking");
            Console.WriteLine("...");
        }
    }
}

namespace SpiritLibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinBrainAttribute : Attribute
    {
        public int MinValue { get; }
        public MinBrainAttribute(int minValue) => MinValue = minValue;
    }
}

namespace SpiritLibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AllowedMonsterTypesAttribute : Attribute
    {
        public MonsterType[] AllowedTypes { get; }
        public AllowedMonsterTypesAttribute(params MonsterType[] types) => AllowedTypes = types;
    }
}

// MonsterType.cs
namespace SpiritLibrary
{
    public enum MonsterType
    {
        Demon,
        Orc,
        Elf,
        Goblin,
        Troll
    }
}