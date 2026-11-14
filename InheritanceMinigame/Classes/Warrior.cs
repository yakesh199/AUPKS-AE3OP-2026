using System;

namespace InheritanceMinigame.Classes
{
    public class Warrior : Character
    {
        public int ShieldBlock { get; set; } = 4;

        public Warrior(string name) : base(name, 120, 15) { }

        public override void PerformAttack(Character target)
        {
            Console.WriteLine($"{Name} swings a heavy greatsword at {target.Name}!");
            target.TakeDamage(AttackPower);
        }

        public override void TakeDamage(int damage)
        {
            int finalDamage = Math.Max(1, damage - ShieldBlock);
            Console.WriteLine($"{Name} blocks {ShieldBlock} damage with their shield!");
            base.TakeDamage(finalDamage);
        }
    }
}
