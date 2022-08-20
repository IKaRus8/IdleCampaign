using System;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IRoadController
    {
        bool IsActive { get; set; }
        float WayPoint { get; }

        void SetPosition(Vector3 position);
    }
}