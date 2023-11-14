﻿using GameInfoModels;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject.SpaceFighter;

namespace GameLogic.Services
{
    public class PlayerNormalState : PlayerBaseState
    {
        private float velocity;
        public PlayerNormalState(PlayerState playerState, float Velocity) : base(playerState, GameState.Normal)
        {
            velocity = Velocity;
        }
        public override void RunCurrentState(Rigidbody playerRigidbody, bool enemyOnScene)
        {
            if (!enemyOnScene)
            {
                playerRigidbody.velocity = Vector3.forward * velocity;
            }
            else
            {
                _stationMonobehavior.SwitchState<PlayerBattleState>();
            }
        }
    }
}