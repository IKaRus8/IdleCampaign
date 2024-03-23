using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfoModels.Interfaces
{
	public interface IEnemyOptions
	{
		public float EnemySquadChaseRadius { get; }

		public float EnemySquadAttackRadius { get; }

		public float EnemyAttackRadius { get; }

	}
}
