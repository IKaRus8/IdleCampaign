using GameInfoModels.Interfaces;
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

		public void RemoveSquadEnemy(IEnemyProvider enemyProvider)
		{
			EnemySquads.Remove(enemyProvider);
		}
	}
}
