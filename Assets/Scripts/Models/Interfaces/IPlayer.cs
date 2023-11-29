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
        public GameObject PlayerObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public Vector3 PlayerPosition { get; }

    }
}
