using GameInfoModels;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerBattleState : PlayerBaseState
    {
        public PlayerBattleState(PlayerState stationMonobehavior):base(stationMonobehavior, GameState.Battle)
        { }
        public override void RunCurrentState(Rigidbody playerRigidbody, bool enemyOnScene)
        {
            if (enemyOnScene)
            {

            }
            else
            {
                _stationMonobehavior.SwitchState<PlayerNormalState>();
            }
        }
    }
}
