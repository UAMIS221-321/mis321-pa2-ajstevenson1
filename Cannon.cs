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
            System.Console.WriteLine($"{attacker.PlayerName} fires their cannon to attack!");
            System.Console.WriteLine($"{defender.PlayerName} defends!");
            Wait();
            double damageDealt = Math.Round((attacker.AttackStrength - defender.DefensivePower) * TypeBonus, 1);
            if(damageDealt < 0)
            {
                damageDealt = 0;
            }
            defender.Health -= damageDealt;
            if(defender.Health < 0)
            {
                defender.Health = 0;
            }
            System.Console.WriteLine($"{attacker.PlayerName} attacked with {attacker.AttackStrength} power and did {damageDealt} damage with their Cannon!\n{defender.PlayerName} loses {damageDealt} health.");
        }

        public void Wait()
        {
            System.Threading.Thread.Sleep(2000);
        }
    }
}