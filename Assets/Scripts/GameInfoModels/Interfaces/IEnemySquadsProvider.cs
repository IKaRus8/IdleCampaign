using GameInfoModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfoModels.Interfaces
{
	public interface IEnemySquadsProvider
	{
		List<IEnemyProvider> EnemySquads { get; set; }

		void RemoveSquadEnemy(IEnemyProvider enemyProvider);
	}
}
