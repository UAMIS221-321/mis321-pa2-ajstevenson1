using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_ajstevenson1.interfaces;

namespace mis321_pa2_ajstevenson1
{
    public class Character 
    {
        public string Name {get; set;}
        public string PlayerName {get; set;}
        public double Health {get; set;}
        public double MaxPower {get; set;}
        public double AttackStrength {get; set;}
        public double DefensivePower {get; set;}
        public IAttack AttackBehavior {get; set;}
        public IDefend DefendBehavior {get; set;}

        public virtual void SetAttackBehavior(Character opponent)
        {
            
        }

        public void DisplayStats()
        {
            System.Console.WriteLine($"{PlayerName} stats: \nCharacter: {Name}\nHealth: {Health}\nMax Power: {MaxPower}\nLast Attack Power: {AttackStrength}\nLast Defensive Power: {DefensivePower}");
        }

        public double GetNumber(double total)
        {
            Random random = new Random();
            string totalString = total.ToString();
            int totalInt = int.Parse(totalString);
            double number = random.Next(totalInt);
            number++;
            return number;
        }

        public void UpdateAttackDefend()
        {
            double number = GetNumber(MaxPower);
            AttackStrength = number;
            number = GetNumber(MaxPower);
            DefensivePower = number;
        }
    }

    
}