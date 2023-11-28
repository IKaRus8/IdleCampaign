using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;

namespace Assets.Scripts.GameLogic.Interfaces
{
    public interface IPlayerProvider
    {
        List<NavMeshAgent> _units { get; }
        void AddUnit(NavMeshAgent agent);
        void RemoveUnit(NavMeshAgent agent);
    }
}
