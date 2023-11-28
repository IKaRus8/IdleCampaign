using Assets.Scripts.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;

namespace GameInfoModels
{
    public class PlayerProvider : IPlayerProvider
    {
        public List<NavMeshAgent> _units { get; set; } = new List<NavMeshAgent>();
        public void AddUnit(NavMeshAgent agent)
        {
            _units.Add(agent);
        }
        public void RemoveUnit(NavMeshAgent agent)
        {
            _units.Remove(agent);
        }

    }
}
