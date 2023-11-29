using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameLogic.Interfaces
{
    public interface IPlayerProvider
    {
        List<IPlayer> Units { get; set; }
        void AddUnit(IPlayer unit);
        void AddUnit(GameObject unit);
        void RemoveUnit(IPlayer unit);
        T GetComponent<T>(IPlayer unit) where T : Component;
    }
}
