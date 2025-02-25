using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Spirit
    {
        public abstract void Passport();
    }
    public class Monster : Spirit
    {
        string name;
        int health, ammo;
        public Monster()
        {
            this.health = 100;
            this.ammo = 100;
            this.name = "Noname";
        }
        public Monster(string name) : this()
        {
            this.name = name;
        }
        public Monster(int health, int ammo, string name)
        {
            this.health = health;
            this.ammo = ammo;
            this.name = name;
        }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > 0) health = value;
                else health = 0;
            }
        }
        public int Ammo
        {
            get
            {
                return ammo;
            }
            set
            {
                if (value > 0) ammo = value;
                else ammo = 0;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        override public void Passport()
        {
            Console.WriteLine("Monster {0} \t health = {1} ammo = {2}", name, health, ammo);
        }
    }

    [MinBrain(3)]
    public class Daemon : Monster
    {
        private int brain;
        private static readonly int minBrain;

        static Daemon()
        {
            var attribute = (MinBrainAttribute)Attribute.GetCustomAttribute(
                typeof(Daemon),
                typeof(MinBrainAttribute)
            );
            minBrain = attribute?.MinValue ?? 3;
        }

        public Daemon() : base("Noname")
        {
            brain = minBrain;
        }

        public Daemon(string name, int brain) : base(name)
        {
            this.brain = brain;
        }

        public Daemon(int health, int ammo, string name, int brain)
            : base(health, ammo, name)
        {
            if (health <= 0)
                throw new ArgumentException("Здоровье не может быть отрицательным", nameof(health));

            if (ammo <= 0)
                throw new ArgumentException("Боеприпасы не могут быть отрицательными", nameof(ammo));
            this.brain = brain;
        }

        public bool IsValid => brain >= minBrain;

        public int Brain => brain;

        // Остальные методы без изменений
        override public void Passport()
        {
            Console.WriteLine("Daemon {0} \t health = {1} ammo = {2} brain = {3}",
                Name, Health, Ammo, brain);
        }

        public void Think()
        {
            Console.Write(Name + " is");
            for (int i = 0; i < brain; ++i) Console.Write(" thinking");
            Console.WriteLine("...");
        }
    }
}

