using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_ajstevenson1.interfaces;

namespace mis321_pa2_ajstevenson1
{
    public class StandardDefend : IDefend
    {
        public void Defend(Character defendingCharacter)
        {
            System.Console.WriteLine($"{defendingCharacter.Name} defends!");
        }
    }
}