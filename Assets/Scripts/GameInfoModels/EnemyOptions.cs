using GameInfoModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameInfoModels
{
	public class EnemyOptions : MonoBehaviour, IEnemyOptions
	{
		[SerializeField]
		private float _enemySquadChaseRadius;
		[SerializeField]
		private float _enemySquadAttackRadius;
		[SerializeField]
		private float _enemyAttackRadius;

		public float EnemySquadChaseRadius { get { return _enemySquadChaseRadius; } }
		public float EnemySquadAttackRadius { get { return _enemySquadAttackRadius; } }
		public float EnemyAttackRadius { get { return _enemyAttackRadius; } }
	}
}
