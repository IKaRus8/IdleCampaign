﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface ICreateEnemy
    {
        void CreateEnemyOnScene(float wayPoint);
    }
}