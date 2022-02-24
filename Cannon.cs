using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_ajstevenson1.interfaces;

namespace mis321_pa2_ajstevenson1
{
    public class Cannon : IAttack
    {
        public double TypeBonus{get; set;}

        public Cannon(Character opponent)
        {
            if(opponent.Name == "Jack Sparrow")
            {
                TypeBonus = 1.2;
            }
            else
            {
                TypeBonus = 1;
            }
        }
        public void Attack(Character attacker, Character defender)
        {
            System.Console.WriteLine("Davy Jones fires his cannon to attack!");
            System.Console.WriteLine($"{defender.Name} defends!");
            double damageDealt = Math.Round((attacker.AttackStrength - defender.DefensivePower) * TypeBonus, 1);
            if(damageDealt < 0)
            {
                damageDealt = 0;
            }
            if(defender.Health < 0)
            {
                defender.Health = 0;
            }
            defender.Health -= damageDealt;
            System.Console.WriteLine($"{attacker.Name} attacked with {attacker.AttackStrength} power and did {damageDealt} damage with his Cannon!\n{defender.Name} loses {damageDealt} health.");
        }
    }
}