using System;

namespace InheritanceMinigame.Classes
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }

        public bool IsAlive => Health > 0;

        protected Character(string name, int health, int attackPower)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            AttackPower = attackPower;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            Console.WriteLine($"{Name} takes {damage} damage! (HP: {Health}/{MaxHealth})");
        }

        public virtual void PerformAttack(Character target) { }
    }
}
