using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    [MinBrain(3)]
    public class Daemon : Monster
    {
        private int brain;

        public Daemon() : base("Noname")
        {
            brain = 1;
        }

        public Daemon(string name, int brain) : base(name)
        {
            this.brain = brain;
        }

        public Daemon(int health, int ammo, string name, int brain) : base(health, ammo, name)
        {
            this.brain = brain;
        }

        public override void Passport()
        {
            Console.WriteLine($"Daemon {Name}\thealth = {Health}\tammo = {Ammo}\tbrain = {brain}");
        }

        public void Think()
        {
            Console.Write(Name + " is");
            for (int i = 0; i < brain; i++) Console.Write(" thinking");
            Console.WriteLine("...");
        }

        public bool IsValidBrain => brain >= 3;
    }
}