using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_ajstevenson1.interfaces;

namespace mis321_pa2_ajstevenson1
{
    public class JackSparrow : Character
    {
        public JackSparrow(string userName)
        {
            Name = "Jack Sparrow";
            PlayerName = userName;
            Health = 100;
            double number = GetNumber(100);
            MaxPower = number;
            number = GetNumber(MaxPower);
            AttackStrength = number;
            number = GetNumber(MaxPower);
            DefensivePower = number;
            DefendBehavior = new StandardDefend();
        }

        public override void SetAttackBehavior(Character opponent)
        {
            AttackBehavior = new Distract(opponent);
        }
    }
}