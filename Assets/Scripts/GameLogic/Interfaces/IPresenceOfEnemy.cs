using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IPresenceOfEnemy
    {
        ReactiveProperty<bool> EnemyOnScene { get;}
        Vector3 enemyPosition { get; }
    }
}
