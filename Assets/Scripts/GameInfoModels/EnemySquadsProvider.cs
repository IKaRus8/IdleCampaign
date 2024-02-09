using GameInfoModels.Interface;
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
		public List<IEnemyProvider> Enemies { get; set; } = new List<IEnemyProvider>();

	}
}
