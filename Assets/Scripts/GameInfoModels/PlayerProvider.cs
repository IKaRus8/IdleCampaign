using Assets.Scripts.GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameInfoModels
{
    public class PlayerProvider : IPlayerProvider
    {
        public List<IPlayer> Units { get; set; } = new List<IPlayer>();
        public void AddUnit(IPlayer unit)
        {
            Units.Add(unit);
        }
        public void AddUnit(GameObject unit)
        {
            Player player = new(unit);
            Units.Add(player);
        }
        public void RemoveUnit(IPlayer unit)
        {
            Units.Remove(unit);
        }
        public T GetComponent<T>(IPlayer unit) where T : Component
        {
            return Units.FirstOrDefault(c => c == unit).PlayerObject.GetComponent<T>();
        }
    }
}
