using GameInfoModels.Interfaces;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfoModels
{
	public class EnemySquadsProvider : IEnemySquadsProvider
	{
		public List<IEnemyProvider> EnemySquads { get; set; } = new List<IEnemyProvider>();

		public IEnemyProvider CreateNewSquad()
		{
			var squadEnemy = new EnemyProvider();
			EnemySquads.Add(squadEnemy);
			return squadEnemy;
		}

		public void RemoveSquadEnemy(IEnemyProvider enemyProvider)
		{
			EnemySquads.Remove(enemyProvider);
		}
	}
}
