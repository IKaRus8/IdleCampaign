using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IPlayer
    {
        IEnemy TargetToPursue { get; set; }
        GameObject PlayerObject { get; set; }
        Vector3 PlayerPosition { get; }
        float MaxHealth { get; }
        float Attack { get; }

    }
}
