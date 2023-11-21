using GameLogic.Interfaces;
using System;

namespace GameLogic.Services
{
    public class RandomGeneration
    {
        Random rnd = new Random();
        public bool IsRandomEventSuccessful(float chance)
        {
            var pick = rnd.Next(101);
            if(pick <= chance)
            {
                return true;
            }
            return false;
        }
    }
}
