using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis321_pa2_ajstevenson1.interfaces
{
    public interface IAttack
    {
        public void Attack(Character attacker, Character defender);
    }
}