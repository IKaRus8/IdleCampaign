using Data.Enums;
using Models;
using Models.Interfaces;
using System.Collections;
using UniRx;
using UnityEngine;

namespace GameLogic.StateEnemy
{

	internal class EnemyAttackState : EnemyBaseState
	{
		public EnemyAttackState() : base(GameState.Attack)
		{
		}

		public override void RunCurrentState(IEnemy enemy)
		{
			if (!enemy.IsAttacking)
				MainThreadDispatcher.StartCoroutine(AttackUnit(enemy));
		}
		IEnumerator AttackUnit(IEnemy enemy)
		{
			enemy.IsAttacking = true;
			enemy.TargetToPursue.TakeDamage(enemy.Damage);
			yield return new WaitForSeconds(enemy.TimeBetweenAttack);
			enemy.IsAttacking = false;
		}
	}
}
