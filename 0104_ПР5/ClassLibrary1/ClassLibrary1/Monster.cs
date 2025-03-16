using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Monster : Spirit
    {
        #region Поля и свойства
        private string _name;
        private int _health;
        private int _ammo;

        [MonsterName(MonsterType.Demon, MonsterType.Undead)] // Разрешены Demon и Undead
        public string Name { get; protected set; }

        public int Health
        {
            get => _health;
            set => _health = value >= 0 ? value : 0;
        }

        public int Ammo
        {
            get => _ammo;
            set => _ammo = value >= 0 ? value : 0;
        }
        #endregion

        #region Конструкторы
        public Monster() : this("Noname")
        {
        }

        public Monster(string name)
        {
            Name = name;
            Health = 100;
            Ammo = 100;
        }

        public Monster(int health, int ammo, string name)
        {
            Name = name;
            Health = health;
            Ammo = ammo;
        }
        #endregion

        #region Методы
        public override void Passport()
        {
            Console.WriteLine($"Monster: {Name}\tHealth: {Health}\tAmmo: {Ammo}");
        }
        #endregion

    }
}