using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IPlayerProvider
    {
        List<IPlayer> Units { get; set; }
        void AddUnit(IPlayer unit);
        void AddUnit(GameObject unit);
        void RemoveUnit(IPlayer unit);
    }
}
