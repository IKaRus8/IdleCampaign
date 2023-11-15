using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerBattleState : PlayerBaseState
    {
        private float approachRadius = 20f;
        private float velocity;

        public PlayerBattleState(PlayerState playerState, float Velocity) : base(playerState, GameState.Battle)
        {
            velocity = Velocity;
        }
        public override void RunCurrentState(Rigidbody playerRigidbody, IPresenceOfEnemy presenceOfEnemy)
        {
            if ((presenceOfEnemy.enemyPosition.z - playerRigidbody.transform.localPosition.z) > (approachRadius+velocity))
            {
                playerRigidbody.velocity = Vector3.forward * velocity;
                return;
            }
        }
    }
}
