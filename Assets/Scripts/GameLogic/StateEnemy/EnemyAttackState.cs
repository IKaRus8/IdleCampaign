using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace GameLogic.StateEnemy
{

	internal class EnemyAttackState : EnemyBaseState
	{
		private float _timeBetweenAttack = 2f;

		public EnemyAttackState() : base(GameState.Attack)
		{
		}

		public override void RunCurrentState(IEnemy enemy)
		{
			if (!enemy.IsAttacking)
				MainThreadDispatcher.StartCoroutine(AttackEnemy(enemy));
		}
		IEnumerator AttackEnemy(IEnemy enemy)
		{
			enemy.IsAttacking = true;
			enemy.TargetToPursue.TakeDamage(enemy.Attack);
			yield return new WaitForSeconds(_timeBetweenAttack);
			enemy.IsAttacking = false;
		}

	}
}
